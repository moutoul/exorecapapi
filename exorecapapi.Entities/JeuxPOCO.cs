namespace exorecapapi.Entities
{
    public class JeuxPOCO
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public int AnneeSortie { get; set; }
        public double Note { get; set; }

        public string Descriptif { get; set; }  

        public int GenreId { get; set; }



    }
}