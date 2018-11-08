using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class İkiliAramaAgaci
    {
         private İkiliAramaAgacDugumu kok;
        
        public İkiliAramaAgaci(İkiliAramaAgacDugumu kok)
        {
            this.kok = kok;
        }

        public İkiliAramaAgaci()
        {

        }
   

        public void Ekle(object deger)
        {
            
            İkiliAramaAgacDugumu tempParent = new İkiliAramaAgacDugumu();
            
            İkiliAramaAgacDugumu tempSearch = kok;

            while (tempSearch != null)
            {
                tempParent = tempSearch;
                
                if ((((KisiBilgileri)deger).Adi) == (((KisiBilgileri)tempSearch.veri).Adi))  
                    return;
                else if (Convert.ToInt32(((KisiBilgileri)deger).Adi[0]) == Convert.ToInt32(((KisiBilgileri)tempSearch.veri).Adi[0]))
                {
                     for(int i=1 ; i< (((KisiBilgileri)deger).Adi).Length ; i++)
                     {
                         if (Convert.ToInt32(((KisiBilgileri)deger).Adi[i]) < Convert.ToInt32(((KisiBilgileri)tempSearch.veri).Adi[i]))
                         {
                             tempSearch = tempSearch.sol;
                             break;
                         }
                         else if(Convert.ToInt32(((KisiBilgileri)deger).Adi[i]) > Convert.ToInt32(((KisiBilgileri)tempSearch.veri).Adi[i]))
                         {
                             tempSearch = tempSearch.sag;
                             break;
                         }
                         else
                             continue;
                    }
                }
                else if(Convert.ToInt32(((KisiBilgileri)deger).Adi[0]) < Convert.ToInt32(((KisiBilgileri)tempSearch.veri).Adi[0]))
                    tempSearch = tempSearch.sol;
                else
                    tempSearch = tempSearch.sag;
            }

            İkiliAramaAgacDugumu eklenecek = new İkiliAramaAgacDugumu(deger);
            
            if (kok == null)
                kok = eklenecek;
            else if (Convert.ToInt32(((KisiBilgileri)deger).Adi[0]) < (Convert.ToInt32(((KisiBilgileri)tempParent.veri).Adi[0])))
                tempParent.sol = eklenecek;
            else if (Convert.ToInt32(((KisiBilgileri)deger).Adi[0]) == Convert.ToInt32(((KisiBilgileri)tempParent.veri).Adi[0]))
            {
                for (int i = 1; i < (((KisiBilgileri)deger).Adi).Length; i++)
                {
                    if (Convert.ToInt32(((KisiBilgileri)deger).Adi[i]) < Convert.ToInt32(((KisiBilgileri)tempParent.veri).Adi[i]))
                    {
                        tempParent.sol = eklenecek;
                        break;
                    }
                    else if (Convert.ToInt32(((KisiBilgileri)deger).Adi[i]) > Convert.ToInt32(((KisiBilgileri)tempParent.veri).Adi[i]))
                    {
                        tempParent.sag = eklenecek;
                        break;
                    }
                    else
                        continue;
                }
            }
            else
                tempParent.sag = eklenecek;
        }



        private İkiliAramaAgacDugumu Successor(İkiliAramaAgacDugumu silDugum)
        {
            İkiliAramaAgacDugumu successorParent = silDugum;
            İkiliAramaAgacDugumu successor = silDugum;
            İkiliAramaAgacDugumu current = silDugum.sag;
            while (current != null)
            {
                successorParent = successor;
                successor = current;
                current = current.sol;
            }
            if (successor != silDugum.sag)
            {
                successorParent.sol = successor.sag;
                successor.sag = silDugum.sag;
            }
            return successor;
        }

        public bool Sil(string deger)
        {
            İkiliAramaAgacDugumu current = kok;
            İkiliAramaAgacDugumu parent = kok;
            bool issol = true;
            
            while (((KisiBilgileri)current.veri).Adi != deger)
            {
                parent = current;  
                if (Convert.ToInt32(deger[0]) < Convert.ToInt32(((KisiBilgileri)current.veri).Adi[0]))
                {
                    issol = true;
                    current = current.sol;
                }
                else if(Convert.ToInt32(deger[0]) == Convert.ToInt32(((KisiBilgileri)current.veri).Adi[0]))
                {
                    for (int i = 1; i < deger.Length; i++)
                    {
                        if (Convert.ToInt32(deger[i]) < Convert.ToInt32(((KisiBilgileri)current.veri).Adi[i]))
                        {
                            current = current.sol;
                            break;
                        }
                        else if (Convert.ToInt32(deger[i]) > Convert.ToInt32(((KisiBilgileri)current.veri).Adi[i]))
                        {
                            current = current.sag;
                            break;
                        }
                        else
                            continue;
                    }
                }
                else
                {
                    issol = false;
                    current = current.sag;
                }
                if (current == null)
                    return false;
            }
            
            if (current.sol == null && current.sag == null)
            {
                if (current == kok)
                    kok = null;
                else if (issol)
                    parent.sol = null;
                else
                    parent.sag = null;
            }
            
            else if (current.sag == null)
            {
                if (current == kok)
                    kok = current.sol;
                else if (issol)
                    parent.sol = current.sol;
                else
                    parent.sag = current.sol;
            }
            else if (current.sol == null)
            {
                if (current == kok)
                    kok = current.sag;
                else if (issol)
                    parent.sol = current.sag;
                else
                    parent.sag = current.sag;
            }
            
            else
            {
                İkiliAramaAgacDugumu successor = Successor(current);
                if (current == kok)
                    kok = successor;
                else if (issol)
                    parent.sol = successor;
                else
                    parent.sag = successor;
                successor.sol = current.sol;
            }
            return true;
        }

        public İkiliAramaAgacDugumu Ara(string anahtar)
        {
            return AraInt(kok, anahtar);
        }
        private İkiliAramaAgacDugumu AraInt(İkiliAramaAgacDugumu dugum, string anahtar)
        {
            if (dugum == null)
                return null;
            else if (((KisiBilgileri)dugum.veri).Adi == anahtar)  
                return dugum;

            else if (Convert.ToInt32(((KisiBilgileri)dugum.veri).Adi[0]) > Convert.ToInt32(anahtar[0]))  //aranan deger dugumdeki veriden kucukse agacın soluna gitmemiz gerek
                return (AraInt(dugum.sol, anahtar));

            else if (Convert.ToInt32(((KisiBilgileri)dugum.veri).Adi[0]) == Convert.ToInt32(anahtar[0]))
            {
                İkiliAramaAgacDugumu d = new İkiliAramaAgacDugumu();
                for (int i = 1; i < ((string)anahtar).Length; i++)
                {
                    if (Convert.ToInt32(((KisiBilgileri)dugum.veri).Adi[i]) > Convert.ToInt32(anahtar[i]))
                    {
                        d = dugum.sol;
                        break;
                    }
                    else if (Convert.ToInt32(((KisiBilgileri)dugum.veri).Adi[i]) < Convert.ToInt32(anahtar[i]))
                    {
                        d = dugum.sag;
                        break;
                    }
                }
                return (AraInt(d, anahtar));
            }
            else
                return (AraInt(dugum.sag, anahtar));
        }


        //public string KisiBilgisi_Goster(string bulunan)
        //{


        //    İkiliAramaAgacDugumu kisi = new İkiliAramaAgacDugumu();
        //    kisi = Ara(bulunan);
            
        //    string temp = "";

        //    temp += "Ad Soyad:" + ((KisiBilgileri)kisi.veri).Adi + Environment.NewLine + "Adres:" + ((KisiBilgileri)kisi.veri).Adres + Environment.NewLine + "Telefon:" + ((KisiBilgileri)kisi.veri).Telefon + Environment.NewLine +
        //        "e-poste" + ((KisiBilgileri)kisi.veri).e_posta + Environment.NewLine + "Uyruk:" + ((KisiBilgileri)kisi.veri).Uyruk + Environment.NewLine + "Doğum Yeri:" + ((KisiBilgileri)kisi.veri).Dogum_Yeri + Environment.NewLine +
        //        "Doğum Tarihi:" + ((KisiBilgileri)kisi.veri).Dogum_Tarihi + Environment.NewLine + "Medeni Durum:" + ((KisiBilgileri)kisi.veri).MedeniDurum + Environment.NewLine + "Yabancı Dil:" + ((KisiBilgileri)kisi.veri).YabanciDil +
        //        Environment.NewLine + "İlgiAlanları:" + ((KisiBilgileri)kisi.veri).İlgiAlanlari + Environment.NewLine + "Referanslar:" + ((KisiBilgileri)kisi.veri).Referans_Kisileri;

        //    return temp;
        //}

    }
    
}
