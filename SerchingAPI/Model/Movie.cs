namespace SerchingAPI.Model
{
    /// <summary>
    /// Корневая информация из ответа
    /// </summary>
    public class MovieRoot
    {
        /// <summary>
        /// Количество страниц
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Количество результата в выдаче
        /// </summary>
        public int TotalResults { get; set; }

        /// <summary>
        /// Количество страниц в выдаче
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Детальная информация по фильму
        /// </summary>
        public MovieResult[] MovieResults { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MovieResult
    {
        /// <summary>
        /// Количество гоолосов
        /// </summary>
        public int VoteCount { get; set; }

        /// <summary>
        /// Уникальный id фильма
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наличие трейлера
        /// </summary>
        public bool Video { get; set; }

        /// <summary>
        /// Оценка
        /// </summary>
        public float VoteAverage { get; set; }

        /// <summary>
        /// Название фильма
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Популярность
        /// </summary>
        public float Popularity { get; set; }

        /// <summary>
        /// Путь к обложке
        /// </summary>
        public string PosterPath { get; set; }

        /// <summary>
        /// Язык оригинала
        /// </summary>
        public string OriginalLanguage { get; set; }

        /// <summary>
        /// Название фильма на языке оригинала
        /// </summary>
        public string OriginalTitle { get; set; }

        /// <summary>
        /// Возрастные ограничения
        /// </summary>
        public int[] GenreIds { get; set; }

        /// <summary>
        /// Путь до обложки
        /// </summary>
        public string BackdropPath { get; set; }

        /// <summary>
        /// Фильм для взрослых, true - да, false - нет
        /// </summary>
        public bool Adult { get; set; }

        /// <summary>
        /// Описание фильма
        /// </summary>
        public string Overview { get; set; }

        /// <summary>
        /// Дата выхода
        /// </summary>
        public string ReleaseDate { get; set; }
    }
}
