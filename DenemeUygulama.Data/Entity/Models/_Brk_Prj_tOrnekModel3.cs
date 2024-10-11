namespace DenemeUygulama.Data.Entity.Models
{
    public class _Brk_Prj_tOrnekModel3 : BaseClass
    {
        public int OrnekModel1Id { get; set; }
        public int OrnekModel2Id { get; set; }

        public string Alan1 { get; set; }
        public string Alan2 { get; set; }

        // İlişkiler
        public virtual tOperasyon tOrnekModel1 { get; set; }
        //public virtual _Brk_Prj_tOrnekModel2 tOrnekModel2 { get; set; }
    }
}
