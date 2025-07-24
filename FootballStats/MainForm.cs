using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ClosedXML.Excel;
using ExcelDataReader;

namespace FootballStats
{
    public partial class MainForm : Form
    {
        private DataTable teamTable = null;
        private DataTable chessTable = null;
        private bool isChessTable = false;
        private readonly string[] splashTexts = new string[]
{
    "Цифры не врут — просто смотри на таблицу!",
    "Лучший матч тот, что уже добавлен!",
    "Сохраняй чаще, чем забиваешь!",
    "Разница голов важнее, чем кажется!",
    "Программа всё помнит — в отличие от судьи!",
    "Победа окрашивается в зелёный!",
    "Поражение? Зато красиво оформлено!",
    "Ничья — тоже результат!",
    "Шахматка расставит всех по местам!",
    "Удаляй аккуратно — как VAR!",
    "Каждый матч на счету!",
    "Путь к чемпионству начинается с Excel!",
    "Сортировка — наше всё!",
    "Загрузи таблицу, загрузи победу!",
    "А если победа? Тогда 3 очка!",
    "Порядок в таблице — порядок в голове!",
    "Турнир идёт — не тормози!",
    "Команды сложатся как мозаика!",
    "Штрафные не считаем — всё по-честному!",
    "Счёт можно изменить, а результат — уже в истории!",
    "Excel + футбол = направление задано!",
    "Багов нет, только офсайды!",
    "Следи за формой — таблицы!",
    "Футбол на бумаге — тоже футбол!",
    "Таблица холодна, как лёд — зато честна!",
    "С возвращением!",
    "Кишлак сила",
    "Приложение создано в честь Щелкунова В.А.",
    "Интересно, что добавит Антоха сегодня?"


};
        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            cmbTeam1.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTeam2.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbViewMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbViewMode.SelectedIndexChanged += cmbViewMode_SelectedIndexChanged;
            Random rnd = new Random();
            labelStatus.Text = splashTexts[rnd.Next(splashTexts.Length)];
        }
        
        private void RecolorChessTableInGrid()
        {
            if (chessTable == null || dgvTable.DataSource != chessTable)
                return;

            for (int i = 0; i < chessTable.Rows.Count; i++)
            {
                for (int j = 1; j < chessTable.Columns.Count; j++)
                {
                    if (i == j - 1)
                    {
                        dgvTable.Rows[i].Cells[j].Style.BackColor = Color.Black;
                        dgvTable.Rows[i].Cells[j].Value = "";
                        continue;
                    }

                    var value = chessTable.Rows[i][j]?.ToString();
                    if (value != null && value.Contains(":"))
                    {
                        var parts = value.Split(':');
                        if (parts.Length == 2 &&
                            int.TryParse(parts[0], out int s1) &&
                            int.TryParse(parts[1], out int s2))
                        {
                            var cell = dgvTable.Rows[i].Cells[j];
                            if (s1 > s2)
                                cell.Style.BackColor = Color.LightGreen;
                            else if (s1 < s2)
                                cell.Style.BackColor = Color.LightCoral;
                            else
                                cell.Style.BackColor = Color.LightYellow;
                        }
                    }
                }
            }
        }
        private void btnLoadExcel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel files (*.xlsx;*.xls)|*.xlsx;*.xls";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });

                            teamTable = null;
                            chessTable = null;

                            cmbViewMode.Items.Clear();
                            SetStatus("Файл Excel успешно загружен");
                            foreach (DataTable table in result.Tables)
                            {
                                if (table.Columns.Contains("Название"))
                                {
                                    teamTable = table;
                                    cmbViewMode.Items.Add("Турнирная таблица");
                                }
                                else
                                {
                                    chessTable = table;
                                    cmbViewMode.Items.Add("Шахматка");
                                }
                            }

                            if (cmbViewMode.Items.Count > 0)
                            {
                                cmbViewMode.SelectedIndex = 0;
                                if (isChessTable)
                                    RecolorChessTableInGrid();
                            }
                            else
                            {
                                MessageBox.Show("Не удалось определить тип данных.");
                                SetStatus("Не удалось определить тип данных");
                            }
                        }
                    }
                }
            }
        }

        private void cmbViewMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbViewMode.SelectedIndex == 0 && teamTable != null)
            {
                dgvTable.DataSource = teamTable;
                isChessTable = false;
            }
            else if (cmbViewMode.SelectedIndex == 1 && chessTable != null)
            {
                dgvTable.DataSource = chessTable;
                RecolorChessTableInGrid();
                isChessTable = true;
            }

            cmbTeam1.Items.Clear();
            cmbTeam2.Items.Clear();
            try
            {
                DataTable source = isChessTable ? chessTable : teamTable;
                foreach (DataRow row in source.Rows)
                {
                    string team = isChessTable ? row[0].ToString() : row["Название"].ToString();
                    cmbTeam1.Items.Add(team);
                    cmbTeam2.Items.Add(team);
                }
            }
            catch { }
            cmbTeam1.Text = "";
            cmbTeam2.Text = "";
            txtScore1.Text = "";
            txtScore2.Text = "";
        }

        private void btnAddMatch_Click(object sender, EventArgs e)
        {
            string team1 = cmbTeam1.Text;
            string team2 = cmbTeam2.Text;

            if (team1 == team2 || string.IsNullOrEmpty(team1) || string.IsNullOrEmpty(team2))
    {
                MessageBox.Show("Выберите две разные команды.");
                SetStatus("Выберите две разные команды");
                return;
            }

            if (!int.TryParse(txtScore1.Text, out int score1) || !int.TryParse(txtScore2.Text, out int score2))
            {
                MessageBox.Show("Введите корректные числовые значения счёта.");
                SetStatus("Введите корректные числовые значения счёта.");
                return;
            }
            if (isChessTable)
                RecolorChessTableInGrid();
            // Проверка на наличие уже сыгранного матча в шахматке
            if (chessTable != null)
            {
                int rowIndex = -1, colIndex = -1;
                for (int i = 0; i < chessTable.Rows.Count; i++)
                {
                    string currentTeam = chessTable.Rows[i][0].ToString().Trim();
                    if (currentTeam == team1.Trim()) rowIndex = i;
                    if (currentTeam == team2.Trim()) colIndex = i;
                }

                if (rowIndex != -1 && colIndex != -1)
                {
                    string cellValue = chessTable.Rows[rowIndex][colIndex + 1]?.ToString();
                    if (!string.IsNullOrWhiteSpace(cellValue))
                    {
                        MessageBox.Show("Этот матч уже добавлен в шахматку.");
                        SetStatus("Этот матч уже добавлен в шахматку");
                        return;
                    }
                }
            }

            // Обновление таблиц
            if (teamTable != null && chessTable != null)
            {
                UpdateTeamStats(team1, score1, score2);
                UpdateTeamStats(team2, score2, score1);
                AddMatchToChessTable(team1, team2, score1, score2);
                dgvTable.DataSource = isChessTable ? chessTable : teamTable;
                SetStatus($"Матч {team1} {score1}:{score2} {team2} добавлен.");
            }
            else if (isChessTable)
            {
                AddMatchToChessTable(team1, team2, score1, score2);
            }
            else
            {
                UpdateTeamStats(team1, score1, score2);
                UpdateTeamStats(team2, score2, score1);
                dgvTable.DataSource = teamTable;
            }
            cmbTeam1.SelectedIndex = -1;
            cmbTeam2.SelectedIndex = -1;
            cmbTeam1.Text = "";
            cmbTeam2.Text = "";
            txtScore1.Text = "";
            txtScore2.Text = "";
        }

        private void UpdateTeamStats(string teamName, int goalsFor, int goalsAgainst)
        {
            foreach (DataRow row in teamTable.Rows)
            {
                if (row["Название"].ToString() == teamName)
                {
                    int games = Convert.ToInt32(row["Игр"]);
                    int wins = Convert.ToInt32(row["Победы"]);
                    int draws = Convert.ToInt32(row["Ничьи"]);
                    int losses = Convert.ToInt32(row["Поражения"]);
                    int scored = Convert.ToInt32(row["Забитые"]);
                    int conceded = Convert.ToInt32(row["Пропущенные"]);
                    int points = Convert.ToInt32(row["Очки"]);

                    games++;
                    scored += goalsFor;
                    conceded += goalsAgainst;

                    if (goalsFor > goalsAgainst)
                    {
                        wins++;
                        points += 3;
                    }
                    else if (goalsFor < goalsAgainst)
                    {
                        losses++;
                    }
                    else
                    {
                        draws++;
                        points += 1;
                    }

                    int difference = scored - conceded;

                    row["Игр"] = games;
                    row["Победы"] = wins;
                    row["Ничьи"] = draws;
                    row["Поражения"] = losses;
                    row["Забитые"] = scored;
                    row["Пропущенные"] = conceded;
                    row["Очки"] = points;
                    row["Разница"] = difference;
                    break;
                }
            }
        }

        private void AddMatchToChessTable(string team1, string team2, int score1, int score2)
        {
            int rowIndex = -1, colIndex = -1;

            for (int i = 0; i < chessTable.Rows.Count; i++)
            {
                string currentTeam = chessTable.Rows[i][0].ToString().Trim();
                if (currentTeam == team1.Trim())
                    rowIndex = i;
                if (currentTeam == team2.Trim())
                    colIndex = i;
            }

            if (rowIndex == -1 || colIndex == -1)
            {
                MessageBox.Show("Одна из команд не найдена в шахматке.");
                SetStatus("Одна из команд не найдена в шахматке");
                return;
            }

            // Добавление результатов
            string result1 = $"{score1}:{score2}";
            string result2 = $"{score2}:{score1}";

            chessTable.Rows[rowIndex][colIndex + 1] = result1;
            chessTable.Rows[colIndex][rowIndex + 1] = result2;

            // Окрашивание только если сейчас отображается шахматка
            if (isChessTable)
            {
                if (dgvTable.Rows.Count > rowIndex && dgvTable.Columns.Count > colIndex + 1)
                {
                    dgvTable.Rows[rowIndex].Cells[colIndex + 1].Style.BackColor =
                        score1 > score2 ? Color.LightGreen :
                        score1 < score2 ? Color.LightCoral :
                        Color.LightYellow;
                }

                if (dgvTable.Rows.Count > colIndex && dgvTable.Columns.Count > rowIndex + 1)
                {
                    dgvTable.Rows[colIndex].Cells[rowIndex + 1].Style.BackColor =
                        score2 > score1 ? Color.LightGreen :
                        score2 < score1 ? Color.LightCoral :
                        Color.LightYellow;
                }
            }
        }

        private void btnSaveTable_Click(object sender, EventArgs e)
        {
            if (teamTable == null && chessTable == null)
            {
                MessageBox.Show("Нет данных для сохранения.");
                SetStatus("Нет данных для сохранения");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel файл|*.xlsx";
                sfd.FileName = "Футбол_данные.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        if (teamTable != null)
                        {
                            var sheet = workbook.Worksheets.Add("Таблица");
                            SaveDataTableToSheet(teamTable, sheet, isChess: false);
                        }

                        if (chessTable != null)
                        {
                            var sheet = workbook.Worksheets.Add("Шахматка");
                            SaveDataTableToSheet(chessTable, sheet, isChess: true);
                        }

                        try
                        {
                            workbook.SaveAs(sfd.FileName);
                            MessageBox.Show("Файл сохранён успешно!");
                            SetStatus("Файл сохранён успешно!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при сохранении: " + ex.Message);
                            SetStatus("Ошибка при сохранении: " + ex.Message);
                        }
                    }
                }
            }
        }
        private void RevertTeamStats(string teamName, int goalsFor, int goalsAgainst)
        {
            foreach (DataRow row in teamTable.Rows)
            {
                if (row["Название"].ToString() == teamName)
                {
                    int games = Convert.ToInt32(row["Игр"]);
                    int wins = Convert.ToInt32(row["Победы"]);
                    int draws = Convert.ToInt32(row["Ничьи"]);
                    int losses = Convert.ToInt32(row["Поражения"]);
                    int scored = Convert.ToInt32(row["Забитые"]);
                    int conceded = Convert.ToInt32(row["Пропущенные"]);
                    int points = Convert.ToInt32(row["Очки"]);

                    games = Math.Max(0, games - 1);
                    scored = Math.Max(0, scored - goalsFor);
                    conceded = Math.Max(0, conceded - goalsAgainst);

                    if (goalsFor > goalsAgainst)
                    {
                        wins = Math.Max(0, wins - 1);
                        points = Math.Max(0, points - 3);
                    }
                    else if (goalsFor < goalsAgainst)
                    {
                        losses = Math.Max(0, losses - 1);
                    }
                    else
                    {
                        draws = Math.Max(0, draws - 1);
                        points = Math.Max(0, points - 1);
                    }

                    int difference = scored - conceded;

                    row["Игр"] = games;
                    row["Победы"] = wins;
                    row["Ничьи"] = draws;
                    row["Поражения"] = losses;
                    row["Забитые"] = scored;
                    row["Пропущенные"] = conceded;
                    row["Очки"] = points;
                    row["Разница"] = difference;

                    break;
                }
            }
        }
        private void SaveDataTableToSheet(DataTable table, IXLWorksheet sheet, bool isChess)
        {
            // Заголовки
            for (int col = 0; col < table.Columns.Count; col++)
            {
                var headerCell = sheet.Cell(1, col + 1);
                headerCell.Value = table.Columns[col].ColumnName;
                headerCell.Style.Font.Bold = true;
                headerCell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                headerCell.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            }

            // Ячейки
            for (int row = 0; row < table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    var value = table.Rows[row][col];
                    var cell = sheet.Cell(row + 2, col + 1);
                    string text = value?.ToString() ?? "";

                    // Для шахматки проверяем пересечение одной и той же команды
                    if (isChess && col > 0 && row == col - 1)
                    {
                        cell.Value = "";
                        cell.Style.Fill.BackgroundColor = XLColor.Black;
                    }
                    else if (isChess && col > 0 && row != col - 1 && text.Contains(":"))
                    {
                        var parts = text.Split(':');
                        if (parts.Length == 2 &&
                            int.TryParse(parts[0], out int s1) &&
                            int.TryParse(parts[1], out int s2))
                        {
                            cell.Value = text;
                            if (s1 > s2)
                                cell.Style.Fill.BackgroundColor = XLColor.LightGreen;
                            else if (s1 < s2)
                                cell.Style.Fill.BackgroundColor = XLColor.LightCoral;
                            else
                                cell.Style.Fill.BackgroundColor = XLColor.LightYellow;
                        }
                        else
                        {
                            cell.Value = text;
                        }
                    }
                    else
                    {
                        if (!isChess && int.TryParse(text, out int number))
                            cell.Value = number;
                        else
                            cell.Value = text;
                    }

                    // Границы для всех ячеек
                    cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    cell.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                }
            }
        }
        private void SetStatus(string message)
        {
            labelStatus.Text = message;
        }
        private void btnSort_Click(object sender, EventArgs e)
        {
            if (teamTable == null || isChessTable)
            {
                MessageBox.Show("Сначала загрузите турнирную таблицу.");
                SetStatus("Сначала загрузите турнирную таблицу.");
                return;
            }

            DataView dv = teamTable.DefaultView;
            dv.Sort = "Очки DESC, Разница DESC";
            teamTable = dv.ToTable();
            dgvTable.DataSource = teamTable;
        }

        private void btnRemoveMatch_Click(object sender, EventArgs e)
        {

            string team1 = cmbTeam1.Text.Trim();
            string team2 = cmbTeam2.Text.Trim();
           
            
                if (team1 == team2 || string.IsNullOrEmpty(team1) || string.IsNullOrEmpty(team2))
                {
                    MessageBox.Show("Выберите две разные команды.");
                SetStatus("Выберите две разные команды");
                return;
                }

                if (!int.TryParse(txtScore1.Text, out int inputScore1) || !int.TryParse(txtScore2.Text, out int inputScore2))
                {
                    MessageBox.Show("Введите корректные числовые значения счёта.");
                SetStatus("Введите корректные числовые значения счёта.");
                return;
                }

                if (chessTable == null)
                {
                    MessageBox.Show("Шахматка не загружена.");
                SetStatus("Шахматка не загружена.");
                return;
                }
            DialogResult result = MessageBox.Show("Вы точно хотите удалить матч " + team1 + " против " + team2, "Подтверждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {

                int rowIndex = -1, colIndex = -1;

                for (int i = 0; i < chessTable.Rows.Count; i++)
                {
                    string teamName = chessTable.Rows[i][0].ToString().Trim();
                    if (teamName == team1)
                        rowIndex = i;
                    if (teamName == team2)
                        colIndex = i;
                }

                if (rowIndex == -1 || colIndex == -1)
                {
                    MessageBox.Show("Одна из команд не найдена в шахматке.");
                    SetStatus("Одна из команд не найдена в шахматке.");
                    return;
                }

                string resultCell = chessTable.Rows[rowIndex][colIndex + 1].ToString();

                if (!resultCell.Contains(":"))
                {
                    MessageBox.Show("Матч между этими командами не найден или некорректный счет");
                    SetStatus("Матч между этими командами не найден или некорректный счет");
                    return;
                }

                var parts = resultCell.Split(':');
                if (parts.Length != 2 || !int.TryParse(parts[0], out int actualScore1) || !int.TryParse(parts[1], out int actualScore2))
                {
                    MessageBox.Show("Неверный формат счёта в шахматке.");
                    SetStatus("Неверный формат счёта в шахматке.");
                    return;
                }

                // Проверка: совпадает ли счёт с введённым
                if (actualScore1 != inputScore1 || actualScore2 != inputScore2)
                {
                    MessageBox.Show($"Счёт {actualScore1}:{actualScore2} в шахматке не совпадает с введённым {inputScore1}:{inputScore2}. Удаление невозможно.");
                    SetStatus($"Счёт {actualScore1}:{actualScore2} в шахматке не совпадает с введённым {inputScore1}:{inputScore2}. Удаление невозможно.");
                    return;
                }

                // Откат статистики
                if (teamTable != null)
                {
                    RevertTeamStats(team1, actualScore1, actualScore2);
                    RevertTeamStats(team2, actualScore2, actualScore1);
                }

                // Удаляем результат из шахматки
                chessTable.Rows[rowIndex][colIndex + 1] = "";
                chessTable.Rows[colIndex][rowIndex + 1] = "";

                if (isChessTable)
                {
                    dgvTable.Rows[rowIndex].Cells[colIndex + 1].Style.BackColor = Color.White;
                    dgvTable.Rows[colIndex].Cells[rowIndex + 1].Style.BackColor = Color.White;
                    
                        RecolorChessTableInGrid();
                }

                dgvTable.DataSource = isChessTable ? chessTable : teamTable;
                MessageBox.Show("Матч успешно удалён.");
                SetStatus($"Матч {team1} vs {team2} удалён.");
                cmbTeam1.SelectedIndex = -1;
                cmbTeam2.SelectedIndex = -1;
                cmbTeam1.Text = "";
                cmbTeam2.Text = "";
                txtScore1.Text = "";
                txtScore2.Text = "";
            }
            else
                return;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            Form1 about = new Form1();
            about.ShowDialog();
        }
    }
}