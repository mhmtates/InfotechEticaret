namespace UIWeb
{
    public static class YaziTemizle
    {
        public static string Temizle(string Data)
        {
            return Data.ToLower().Replace(" ", "-").Replace("ş", "s").Replace("ü", "u").Replace("ğ", "g").Replace("ç", "c").Replace("ı", "i").Replace("_", "-").Replace("ö", "o").Replace("+", "-").Replace("#", "-").Replace("&", "-").Replace(":", "-").Replace(".", "-").Replace("'", "").Replace(",", "-");
        }
    }
}
