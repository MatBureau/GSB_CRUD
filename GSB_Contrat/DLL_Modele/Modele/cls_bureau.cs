namespace DLL_Modele
{
    public class cls_bureau: cls_ID
    {
        private int _CodeBureau;
        private string _VilleBureau;
        private string _Pays;
        public cls_bureau(int p_CodeBureau,string p_VilleBureau, string p_Pays):base(p_CodeBureau)
        {
            _CodeBureau = p_CodeBureau;
            _VilleBureau = p_VilleBureau;
            _Pays = p_Pays;
        }

        public int CodeBureau
        {
            get { return _CodeBureau; }
            set { _CodeBureau = value; }
        }
        public string VilleBureau
        {
            get { return _VilleBureau; }
            set { _VilleBureau = value; }
        }
        public string Pays
        {
            get { return _Pays; }
            set { _Pays = value; }
        }
    }
}