internal class Program
{
    private static void Main(string[] args)
    {
        string sifreYazi;
        int anahtarSayac = 0;
        bool TurkceMi(char karakter)
        {
            if (karakter == 'ç' || karakter == 'Ç' || karakter == 'ğ' || karakter == 'Ğ' || karakter == 'ı' || karakter == 'İ' || karakter == 'ö' || karakter == 'Ö' || karakter == 'ş' || karakter == 'Ş' || karakter == 'ü' || karakter == 'Ü')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        string Sifrele(string yazi, string anahtar)
        {
            
            sifreYazi = "";


            for (int i = 0, s = yazi.Length; i < s; i++)
            {
                // Eğer karakterler harf ise ve Türkçe karakter değilse Vigenere şifreleme formülü uygulanıyor
                if (char.IsLetter(yazi[i]) && !TurkceMi(yazi[i]))
                {
                    // Vigenere formülü için değişken oluşturuyorum
                    int formul;

                    // Karakter büyük harfse formül bu şekilde oluyor
                    if (char.IsUpper(yazi[i]))
                    {
                        formul = ((yazi[i] - 65) + (char.ToUpper(anahtar[anahtarSayac % anahtar.Length]) - 65)) % 26;
                        sifreYazi += (char)(formul + 66);
                        anahtarSayac++;
                    }
                    // Karakter küçük harfse formül bu şekilde oluyor
                    else
                    {
                        formul = ((yazi[i] - 97) + (char.ToLower(anahtar[anahtarSayac % anahtar.Length]) - 97)) % 26;
                        sifreYazi += (char)(formul + 98);
                        anahtarSayac++;
                    }
                }
                // Eğer karakterler harf değilse ve Türkçe ise, olduğu gibi sifreYazi değişkenine aktarılıyor
                else
                {
                    sifreYazi += yazi[i];
                }
            }

            // Şifrelenmiş yazıyı gönderiyorum
            return new string(sifreYazi);
        }

        

        

        //Dosyanın ismini kayıt ediyorum
        
        string dosyaPath = "sifrele.txt"
        string txtDosya = File.ReadAllText(dosyaPath);

        // Anahtar kelimeyi kullanıcıdan istiyorum
        Console.WriteLine("Anahtar kelimeyi giriniz:");
        string anahtar = Console.ReadLine();

        //sifrelenmis adı altında string değer oluşturup Sifrele methodunu kullnarak sifrelenmiş halini değişkene atıyorum.
        string sifrelenmis = Sifrele(txtDosya, anahtar);

        //Yazının şifrelenmiş halini dosyaya yazdırıyorum.
        File.WriteAllText(dosyaPath, sifrelenmis);
        Console.WriteLine("Metin şifrenelerek kayıt edilmiştir!");

        //.exe olarak açıldığında console kapanmasın diye tuşa basılmasını bekletiyorum
        Console.ReadKey();
    }
}