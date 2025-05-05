namespace eliminador_de_comentaris
{
    class Program
    {
        static void Main(string[] args)
        { string fichierSource = "C://Users//charf//Desktop//prova.cs";
        string fichierDestination = "C://Users//charf//Desktop//prova_nou.cs";

        bool dansCommentaireMultilignes = false;

        try
        {
            using StreamReader lecteur = new StreamReader(fichierSource);
            using StreamWriter ecrivain = new StreamWriter(fichierDestination);

            string ligne;

            while ((ligne = lecteur.ReadLine()) != null)
            {
                string ligneNettoyee = "";
                int i = 0;

                while (i < ligne.Length)
                {
                 
                    if (!dansCommentaireMultilignes && i + 1 < ligne.Length && ligne[i] == '/' && ligne[i + 1] == '*')
                    {
                        dansCommentaireMultilignes = true;
                        i += 2;
                    }
                   
                    else if (dansCommentaireMultilignes && i + 1 < ligne.Length && ligne[i] == '*' && ligne[i + 1] == '/')
                    {
                        dansCommentaireMultilignes = false;
                        i += 2;
                    }
                   
                    else if (!dansCommentaireMultilignes && i + 1 < ligne.Length && ligne[i] == '/' && ligne[i + 1] == '/')
                    {
                        i = ligne.Length; 
                    }
                 
                    else if (!dansCommentaireMultilignes)
                    {
                        ligneNettoyee += ligne[i];
                        i++;
                    }
                    else
                    {
                        i++; 
                    }
                }

                if (!string.IsNullOrWhiteSpace(ligneNettoyee))
                    ecrivain.WriteLine(ligneNettoyee);
            }

            Console.WriteLine($"Les commentaires ont été supprimés. Fichier nettoyé : {fichierDestination}");
        }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Une erreur s'est produite : " + ex.Message);
                    }

        }
    }
}