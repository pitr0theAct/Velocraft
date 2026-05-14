namespace Demo.TestEntities
{
    /// <summary>
    /// Единый источник тестовых данных для конфигуратора велосипедов Velocraft.
    /// Все названия деталей, используемые в тестах, определяются здесь.
    /// При изменении каталога правим ОДНО место — тесты подтянут данные автоматически.
    /// </summary>
    public static class VelocraftTestData
    {
        // ── Рамы ──────────────────────────────────────────
        public const string DefaultFrameName =
            "Specialized Chisel Hardtail 29 Frame Kit - S Gloss Purple";

        public const string AlternativeFrameName =
            "Specialized Chisel Hardtail 29 Frame Kit - M Gloss Purple";

        public const string DefaultBrandName = "Specialized";

        // ── Вилки ─────────────────────────────────────────
        public const string DefaultForkName =
            "RockShox Domain Gold R DebonAir Boost 29";

        // ── Колёса ────────────────────────────────────────
        public const string DefaultWheelsName =
            "bc original Loamer MK2 Center Lock Disc 29";

        // ── Покрышки ──────────────────────────────────────
        public const string DefaultTiresName =
            "Specialized Butcher Grid Trail T9";
    }
}
