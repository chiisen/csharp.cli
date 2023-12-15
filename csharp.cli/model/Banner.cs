namespace csharp.cli.model
{
    /*
     {
        "banner_src": "https://picture.stdo.site/banner/web/my-mm/banner01.jpg",
        "banner_url": "",
        "banner_urltype": 0,
        "sort": "1",
        "banner_type": 1,
        "lang": "my-mm"
     }
     */
    /// <summary>
    /// Banner 的 Json 設定格式
    /// </summary>
    internal class Banner
    {
        public string? banner_src { get; set; }
        public string? banner_url { get; set; }
        public int banner_urltype { get; set; }
        public int sort { get; set; }
        public int banner_type { get; set; }
        public string? lang { get; set; }
    }
}
