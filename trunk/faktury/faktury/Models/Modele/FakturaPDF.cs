using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace faktury.Models.Modele
{
    public static class FakturaPDF
    {
        public static MemoryStream StworzPDF(int id)
        {
            using (FakturyDBEntitiess db = new FakturyDBEntitiess())
            {
                FakturaSprzedazy faktura = new FakturaSprzedazy();
                faktura.dokumentSprzedazy = SprzedazModel.DokumentSprzdazyPoID(id);
                faktura.ListaProduktowSprzedazy = ProduktyFakturySprzedazyModel.PobierzProduktyPoID(id);
                faktura.ListaRozliczeniaSprzedazy = RozliczenieFakturySprzedazyModel.PobierzListeRozliczenSprzedazyPoID(id);
                PrzedsiebiorstwoRepozytorium Przedsiebiorca =
                        new PrzedsiebiorstwoRepozytorium(
                            PrzedsiebiorstwoModel.PobierzPrzedsiebiorstwoPoID(
                            (db.DanePrzedsiebiorstwa.SingleOrDefault(d => d.DataZablokowania == null)).DanePrzedsiebiorstwaID));
                OdbiorcyRepozytorium Odbiorca = new OdbiorcyRepozytorium(OdbiorcyModel.PobierzOdbiorcePoID(faktura.dokumentSprzedazy.KlientID));

                using (MemoryStream ms = new MemoryStream())
                {
                    Document doc = new Document(PageSize.A4, 15, 15, 15, 15);
                    try
                    {
                        PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                        BaseFont bfComic = BaseFont.CreateFont("c:\\windows\\fonts\\calibri.ttf", BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                        var boldTabela = new Font(bfComic, 11, Font.BOLD);
                        var tytulFont = new Font(bfComic, 17, Font.BOLD);
                        var bodyFont = new Font(bfComic, 11, Font.NORMAL);

                        doc.Open();

                        doc.AddCreationDate();

                        Paragraph heading = new Paragraph(faktura.dokumentSprzedazy.TypDokumentu, tytulFont);
                        heading.Alignment = 1;
                        heading.Leading = 40f;
                        doc.Add(heading);

                        var tabelaGora = new PdfPTable(4);
                        tabelaGora.HorizontalAlignment = 1;
                        tabelaGora.SpacingBefore = 10;
                        tabelaGora.SpacingAfter = 25;
                        tabelaGora.DefaultCell.Border = 0;

                        tabelaGora.AddCell(new Phrase("Numer", boldTabela));
                        tabelaGora.AddCell(new Phrase(faktura.dokumentSprzedazy.NrDokumentu, bodyFont));
                        tabelaGora.AddCell("");
                        tabelaGora.AddCell(new Phrase("ORYGINAŁ/KOPIA", bodyFont));
                        tabelaGora.AddCell(new Phrase("Data sprzedaży", boldTabela));
                        tabelaGora.AddCell(new Phrase(faktura.dokumentSprzedazy.DataSprzedazy.ToShortDateString(), bodyFont));
                        tabelaGora.AddCell(new Phrase("Termin płatności", boldTabela));
                        tabelaGora.AddCell(new Phrase(faktura.dokumentSprzedazy.TerminPlatnosci.ToShortDateString(), bodyFont));
                        tabelaGora.AddCell(new Phrase("Data wystawienia", boldTabela));
                        tabelaGora.AddCell(new Phrase(faktura.dokumentSprzedazy.DataWystawienia.ToShortDateString(), bodyFont));
                        tabelaGora.AddCell(new Phrase("Sposób zapłaty", boldTabela));
                        tabelaGora.AddCell(new Phrase(faktura.dokumentSprzedazy.FormyPlatnosci.Nazwa, bodyFont));
                        doc.Add(tabelaGora);

                        var tabelaOdbiorca = new PdfPTable(2);
                        tabelaOdbiorca.HorizontalAlignment = 1;
                        tabelaOdbiorca.SpacingBefore = 10;
                        tabelaOdbiorca.SpacingAfter = 25;
                        tabelaOdbiorca.DefaultCell.Border = 4;

                        tabelaOdbiorca.AddCell(new Phrase("Sprzedawca", boldTabela));
                        tabelaOdbiorca.AddCell(new Phrase("Nabywca", boldTabela));
                        tabelaOdbiorca.AddCell(new Phrase(Przedsiebiorca.PelnaNazwaPrzedsiebiorstwa, bodyFont));
                        tabelaOdbiorca.AddCell(new Phrase(Odbiorca.PelnaNazwaOdbiorcy, bodyFont));
                        if (string.IsNullOrEmpty(Przedsiebiorca.Przedsiebiorstwo.NrMieszkania))
                            tabelaOdbiorca.AddCell(new Phrase("ul. " + Przedsiebiorca.Przedsiebiorstwo.Ulica + " " +
                                Przedsiebiorca.Przedsiebiorstwo.NrDomu, bodyFont));
                        else
                            tabelaOdbiorca.AddCell(new Phrase("ul. " + Przedsiebiorca.Przedsiebiorstwo.Ulica + " " +
                                Przedsiebiorca.Przedsiebiorstwo.NrDomu + "/" + Przedsiebiorca.Przedsiebiorstwo.NrMieszkania, bodyFont));
                        if (string.IsNullOrEmpty(Odbiorca.Odbiorca.Ulica))
                            tabelaOdbiorca.AddCell(new Phrase("ul. " + Odbiorca.Odbiorca.Ulica + " " +
                                Odbiorca.Odbiorca.NrDomu, bodyFont));
                        else
                            tabelaOdbiorca.AddCell(new Phrase("ul. " + Odbiorca.Odbiorca.Ulica + " " +
                                Odbiorca.Odbiorca.NrDomu + "/" + Odbiorca.Odbiorca.NrMieszkania, bodyFont));
                        tabelaOdbiorca.AddCell(new Phrase(Przedsiebiorca.KodPocztowy + " " + Przedsiebiorca.Miejscowosc, bodyFont));
                        tabelaOdbiorca.AddCell(new Phrase(Odbiorca.KodPocztowy + " " + Odbiorca.Miejscowosc, bodyFont));
                        tabelaOdbiorca.AddCell(new Phrase("NIP: " + Przedsiebiorca.Przedsiebiorstwo.Nip, bodyFont));
                        tabelaOdbiorca.AddCell(new Phrase("NIP: " + Odbiorca.Odbiorca.Nip, bodyFont));

                        doc.Add(tabelaOdbiorca);

                        var TabelaListaTowarow = new PdfPTable(8);
                        //lp    |Nazwa  |jm |Ilosc  |wartośćNetto   |VAT    |WartośćVAT |WartośćBturro|
                        //0,5   |4.5    |0.5|1      |2              |1,5    |2          |2            |
                        float[] widths = new float[] { 0.5f, 4.5f, 0.5f, 1f, 1.5f, 1f, 1.5f, 1.5f };
                        TabelaListaTowarow.SetWidths(widths);
                        TabelaListaTowarow.SpacingBefore = 15;
                        TabelaListaTowarow.SpacingAfter = 20;

                        TabelaListaTowarow.AddCell(new Phrase("Lp", boldTabela));
                        TabelaListaTowarow.AddCell(new Phrase("Nazwa", boldTabela));
                        TabelaListaTowarow.AddCell(new Phrase("jm", boldTabela));
                        TabelaListaTowarow.AddCell(new Phrase("Ilość", boldTabela));
                        TabelaListaTowarow.AddCell(new Phrase("Warotść netto", boldTabela));
                        TabelaListaTowarow.AddCell(new Phrase("VAT", boldTabela));
                        TabelaListaTowarow.AddCell(new Phrase("Warotść VAT", boldTabela));
                        TabelaListaTowarow.AddCell(new Phrase("Warotść Brutto", boldTabela));
                        int i = 1;
                        foreach (var item in faktura.ListaProduktowSprzedazy)
                        {
                            TabelaListaTowarow.AddCell(new Phrase(i.ToString(), bodyFont));
                            i++;
                            TabelaListaTowarow.AddCell(new Phrase(item.TowaryUslugi.Nazwa, bodyFont));
                            TabelaListaTowarow.AddCell(new Phrase(item.TowaryUslugi.JednostkiMiar.Nazwa,bodyFont));
                            //TabelaListaTowarow.AddCell(new Phrase("jm", bodyFont));
                            TabelaListaTowarow.AddCell(new Phrase((item.Ilosc).ToString(), bodyFont));
                            TabelaListaTowarow.AddCell(new Phrase((item.WartoscNetto).ToString(), bodyFont));
                            TabelaListaTowarow.AddCell(new Phrase((item.TowaryUslugi.StawkiVat.Wartosc).ToString(), bodyFont));
                            TabelaListaTowarow.AddCell(new Phrase((item.WartoscBrutto - item.WartoscNetto).ToString(), bodyFont));
                            TabelaListaTowarow.AddCell(new Phrase((item.WartoscBrutto).ToString(), bodyFont));
                        }

                        PdfPCell PoleWartosc = new PdfPCell(new Phrase("Wartość:", boldTabela));
                        PoleWartosc.Rowspan = 1;
                        PoleWartosc.Colspan = 4;
                        PoleWartosc.HorizontalAlignment = Element.ALIGN_RIGHT;
                        PoleWartosc.VerticalAlignment = Element.ALIGN_RIGHT;
                        PoleWartosc.Border = 0;
                        TabelaListaTowarow.AddCell(PoleWartosc);
                        TabelaListaTowarow.AddCell(new Phrase((faktura.dokumentSprzedazy.WartoscNetto).ToString(), bodyFont));
                        TabelaListaTowarow.AddCell("");
                        TabelaListaTowarow.AddCell(new Phrase((faktura.dokumentSprzedazy.WartoscBrutto - faktura.dokumentSprzedazy.WartoscNetto).ToString(), bodyFont));
                        TabelaListaTowarow.AddCell(new Phrase((faktura.dokumentSprzedazy.WartoscBrutto).ToString(), bodyFont));
                        doc.Add(TabelaListaTowarow);

                        var fontText = new Font(bfComic, 12, Font.NORMAL);
                        var fontTextBold = new Font(bfComic, 12, Font.BOLD);

                        Chunk Zaplata = new Chunk("Razem do zapłaty: ", fontText);
                        Chunk ZaplataIlosc = new Chunk((faktura.dokumentSprzedazy.WartoscBrutto).ToString() + " " +
                            faktura.dokumentSprzedazy.Kraje.WalutaSkrot, fontTextBold);
                        Phrase drukZaplaty = new Phrase();
                        drukZaplaty.Add(Zaplata);
                        drukZaplaty.Add(ZaplataIlosc);

                        var tabelaZaplata = new PdfPTable(1);
                        tabelaZaplata.HorizontalAlignment = 1;
                        tabelaZaplata.SpacingBefore = 10;
                        tabelaZaplata.SpacingAfter = 25;
                        tabelaZaplata.DefaultCell.Border = 0;

                        Chunk ZaplataSlownie = new Chunk("Słownie: ", fontText);
                        Chunk SlownieWartosc = new Chunk(kowtaSlownie((faktura.dokumentSprzedazy.WartoscBrutto).ToString()), fontTextBold);
                        Phrase drukSłownie = new Phrase();
                        drukSłownie.Add(ZaplataSlownie);
                        drukSłownie.Add(SlownieWartosc);

                        tabelaZaplata.AddCell(drukZaplaty);
                        tabelaZaplata.AddCell(drukSłownie);
                        doc.Add(tabelaZaplata);

                        var tabelaUwagi = new PdfPTable(1);
                        tabelaUwagi.HorizontalAlignment = 1;
                        tabelaUwagi.SpacingBefore = 10;
                        tabelaUwagi.SpacingAfter = 25;
                        tabelaUwagi.DefaultCell.Border = 0;
                        tabelaUwagi.AddCell(new Phrase("Uwagi", boldTabela));
                        tabelaUwagi.AddCell(new Phrase(faktura.dokumentSprzedazy.Uwagi, bodyFont));
                        tabelaUwagi.AddCell("");
                        doc.Add(tabelaUwagi);

                        var tabelaInfo = new PdfPTable(1);
                        tabelaInfo.HorizontalAlignment = 1;
                        tabelaInfo.SpacingBefore = 10;
                        tabelaInfo.SpacingAfter = 30;
                        tabelaInfo.DefaultCell.Border = 0;
                        tabelaInfo.AddCell(new Phrase("Prosimy o dokonanie płatności na nr rachunku:", boldTabela));
                        tabelaInfo.AddCell(new Phrase(faktura.dokumentSprzedazy.Banki.NrBanku + " Bank " + faktura.dokumentSprzedazy.Banki.Nazwa, boldTabela));
                        tabelaInfo.AddCell(new Phrase("W tytule przelewu prosimy podać nr faktury. Dziękujemy", boldTabela));
                        doc.Add(tabelaInfo);


                        var fontPodpisy = new Font(bfComic, 7, Font.NORMAL);

                        var tabelaPodpisy = new PdfPTable(2);
                        tabelaPodpisy.HorizontalAlignment = 1;
                        tabelaPodpisy.SpacingBefore = 30;
                        tabelaPodpisy.DefaultCell.Border = 0;

                        PdfPCell PodpisK1 = new PdfPCell(new Phrase("____________________________"));
                        PdfPCell PodpisK2 = new PdfPCell(new Phrase("____________________________"));
                        PdfPCell Podpis1 = new PdfPCell(new Phrase("Podpis osoby uprawnionej", fontPodpisy));

                        PdfPCell Podpis2 = new PdfPCell(new Phrase("Data i podpis osoby", fontPodpisy));
                        PdfPCell Podpis3 = new PdfPCell(new Phrase("do wystawienia faktury", fontPodpisy));

                        PdfPCell Podpis4 = new PdfPCell(new Phrase("odbierającej fakturę", fontPodpisy));

                        Podpis1.VerticalAlignment = Podpis2.VerticalAlignment = Podpis3.VerticalAlignment = Podpis4.VerticalAlignment = PodpisK1.VerticalAlignment = PodpisK2.VerticalAlignment = Element.ALIGN_CENTER;
                        Podpis1.HorizontalAlignment = Podpis2.HorizontalAlignment = Podpis3.HorizontalAlignment = Podpis4.HorizontalAlignment = PodpisK1.HorizontalAlignment = PodpisK2.HorizontalAlignment = Element.ALIGN_CENTER;

                        Podpis1.Border = Podpis2.Border = Podpis3.Border = Podpis4.Border = PodpisK1.Border = PodpisK2.Border = 0;

                        tabelaPodpisy.AddCell(PodpisK1);
                        tabelaPodpisy.AddCell(PodpisK1);
                        tabelaPodpisy.AddCell(Podpis1);
                        tabelaPodpisy.AddCell(Podpis2);
                        tabelaPodpisy.AddCell(Podpis3);
                        tabelaPodpisy.AddCell(Podpis4);
                        doc.Add(tabelaPodpisy);
                    }
                    catch (DocumentException dex)
                    {
                        throw (dex);
                    }
                    catch (IOException ioex)
                    {
                        throw (ioex);
                    }
                    finally
                    {
                        doc.Close();
                    }

                    return ms;
                }

            }
        }


        public static string kowtaSlownie(string doub)
        {
            string kwota = string.Empty;
            string db = string.Empty;
            string post = "tysięcy";
            if (doub.Length < 9)
            {
                for (int i = 0; i < 9 - doub.Length; i++)
                    db += "0";
            }
            db += doub;

            if (db.Substring(0, 1) == "1")
                kwota += " sto";
            else if (db.Substring(0, 1) == "2")
                kwota += " dwieście";
            else if (db.Substring(0, 1) == "3")
                kwota += " trzysta";
            else if (db.Substring(0, 1) == "4")
                kwota += " czterysta";
            else if (db.Substring(0, 1) == "5")
                kwota += " pięćset";
            else if (db.Substring(0, 1) == "6")
                kwota += " sześćset";
            else if (db.Substring(0, 1) == "7")
                kwota += " siedemset";
            else if (db.Substring(0, 1) == "8")
                kwota += " osiemset";
            else if (db.Substring(0, 1) == "9")
                kwota += " dziewięćset";


            if (db.Substring(1, 1) == "2")
                kwota += " dwadzieścia";
            else if (db.Substring(1, 1) == "3")
                kwota += " trzydzieści";
            else if (db.Substring(1, 1) == "4")
                kwota += " czterdeści";
            else if (db.Substring(1, 1) == " 5")
                kwota += " pięćdziesiąt";
            else if (db.Substring(1, 1) == "6")
                kwota += " sześćdziesiąt";
            else if (db.Substring(1, 1) == "7")
                kwota += " siedemdziesiąt";
            else if (db.Substring(1, 1) == "8")
                kwota += " osiemdziesiąt";
            else if (db.Substring(1, 1) == "9")
                kwota += " dziewięćdziesiąt";


            if (db.Substring(1, 2) == "10")
                kwota += " dziesięć";
            else if (db.Substring(1, 2) == "11")
                kwota += " jedenaście";
            else if (db.Substring(1, 2) == "12")
                kwota += " dwanaście";
            else if (db.Substring(1, 2) == "13")
                kwota += " trzynaście";
            else if (db.Substring(1, 2) == "14")
                kwota += " czternaście";
            else if (db.Substring(1, 2) == "15")
                kwota += " piętnaście";
            else if (db.Substring(1, 2) == "16")
                kwota += " szesnaście";
            else if (db.Substring(1, 2) == "17")
                kwota += " siedemnaście";
            else if (db.Substring(1, 2) == "18")
                kwota += " osiemnaście";
            else if (db.Substring(1, 2) == "19")
                kwota += " dziewiętnaście";

            else if (db.Substring(2, 1) == "1")
            {
                kwota += " jeden";
                if (kwota == " jeden")
                    post = "tysiąc";
            }
            else if (db.Substring(2, 1) == "2")
            {
                kwota += " dwa";
                post = "tysiące";
            }
            else if (db.Substring(2, 1) == "3")
            {
                kwota += " trzy";
                post = "tysiące";
            }
            else if (db.Substring(2, 1) == "4")
            {
                kwota += " cztery";
                post = "tysiące";
            }
            else if (db.Substring(2, 1) == "5")
                kwota += " pięć";
            else if (db.Substring(2, 1) == "6")
                kwota += " sześć";
            else if (db.Substring(2, 1) == "7")
                kwota += " siedem";
            else if (db.Substring(2, 1) == "8")
                kwota += " osiem";
            else if (db.Substring(2, 1) == "9")
                kwota += " dziewięć";
            if (doub.Length > 6)
                kwota += " " + post;

            if (db.Substring(3, 1) == "1")
                kwota += " sto";
            else if (db.Substring(3, 1) == "2")
                kwota += " dwieście";
            else if (db.Substring(3, 1) == "3")
                kwota += " trzysta";
            else if (db.Substring(3, 1) == "4")
                kwota += " czterysta";
            else if (db.Substring(3, 1) == "5")
                kwota += " pięćset";
            else if (db.Substring(3, 1) == "6")
                kwota += " sześćset";
            else if (db.Substring(3, 1) == "7")
                kwota += " siedemset";
            else if (db.Substring(3, 1) == "8")
                kwota += " osiemset";
            else if (db.Substring(3, 1) == "9")
                kwota += " dziewięćset";


            if (db.Substring(4, 1) == "2")
                kwota += " dwadzieścia";
            else if (db.Substring(4, 1) == "3")
                kwota += " trzydzieści";
            else if (db.Substring(4, 1) == "4")
                kwota += " czterdzieści";
            else if (db.Substring(4, 1) == "5")
                kwota += " pięćdziesiąt";
            else if (db.Substring(4, 1) == "6")
                kwota += " sześćdziesiąt";
            else if (db.Substring(4, 1) == "7")
                kwota += " siedemdziesiąt";
            else if (db.Substring(4, 1) == "8")
                kwota += " osiemdziesiąt";
            else if (db.Substring(4, 1) == "9")
                kwota += " dziewięćdziesiąt";

            if (db.Substring(4, 2) == "10")
                kwota += " dziesięć";
            else if (db.Substring(4, 2) == "11")
                kwota += " jedenaście";
            else if (db.Substring(4, 2) == "12")
                kwota += " dwanaście";
            else if (db.Substring(4, 2) == "13")
                kwota += " trzynaście";
            else if (db.Substring(4, 2) == "14")
                kwota += " czternaście";
            else if (db.Substring(4, 2) == "15")
                kwota += " piętnaście";
            else if (db.Substring(4, 2) == "16")
                kwota += " szesnaście";
            else if (db.Substring(4, 2) == "17")
                kwota += " siedemnaście";
            else if (db.Substring(4, 2) == "18")
                kwota += " osiemnaście";
            else if (db.Substring(4, 2) == "19")
                kwota += " dziewiętnaście";
            else if (db.Substring(5, 1) == "1")
                kwota += " jeden";
            else if (db.Substring(5, 1) == "2")
                kwota += " dwa";
            else if (db.Substring(5, 1) == "3")
                kwota += " trzy";
            else if (db.Substring(5, 1) == "4")
                kwota += " cztery";
            else if (db.Substring(5, 1) == "5")
                kwota += " pięć";
            else if (db.Substring(5, 1) == "6")
                kwota += " sześć";
            else if (db.Substring(5, 1) == "7")
                kwota += " siedem";
            else if (db.Substring(5, 1) == "8")
                kwota += " osiem";
            else if (db.Substring(5, 1) == "9")
                kwota += " dziewięć";
            if (kwota == string.Empty)
                kwota += "zero";
            kwota += " zł";

            if (db.Substring(7, 1) == "2")
                kwota += " dwadzieścia";
            else if (db.Substring(7, 1) == "3")
                kwota += " trzydzieści";
            else if (db.Substring(7, 1) == "4")
                kwota += " czterdzieści";
            else if (db.Substring(7, 1) == "5")
                kwota += " pięćdziesiąt";
            else if (db.Substring(7, 1) == "6")
                kwota += " sześćdziesiąt";
            else if (db.Substring(7, 1) == "7")
                kwota += " siedemdziesiąt";
            else if (db.Substring(7, 1) == "8")
                kwota += " osiemdziesiąt";
            else if (db.Substring(7, 1) == "9")
                kwota += " dziewięćdziesiąt";

            if (db.Substring(7, 2) == "10")
                kwota += " dziesięć";
            else if (db.Substring(7, 2) == "11")
                kwota += " jedenaście";
            else if (db.Substring(7, 2) == "12")
                kwota += " dwanaście";
            else if (db.Substring(7, 2) == "13")
                kwota += " trzynaście";
            else if (db.Substring(7, 2) == "14")
                kwota += " czternaście";
            else if (db.Substring(7, 2) == "15")
                kwota += " piętnaście";
            else if (db.Substring(7, 2) == "16")
                kwota += " szesnaście";
            else if (db.Substring(7, 2) == "17")
                kwota += " siedemnaście";
            else if (db.Substring(7, 2) == "18")
                kwota += " osiemnaście";
            else if (db.Substring(7, 2) == "19")
                kwota += " dziewiętnaście";
            else if (db.Substring(7, 2) == "00")
                kwota += " zero";
            else if (db.Substring(8, 1) == "1")
                kwota += " jeden";
            else if (db.Substring(8, 1) == "2")
                kwota += " dwa";
            else if (db.Substring(8, 1) == "3")
                kwota += " trzy";
            else if (db.Substring(8, 1) == "4")
                kwota += " cztery";
            else if (db.Substring(8, 1) == "5")
                kwota += " pięć";
            else if (db.Substring(8, 1) == "6")
                kwota += " sześć";
            else if (db.Substring(8, 1) == "7")
                kwota += " siedem";
            else if (db.Substring(8, 1) == "8")
                kwota += " osiem";
            else if (db.Substring(8, 1) == "9")
                kwota += " dziewięć";
            kwota += " gr";
            return kwota;
        }

    }



    // public void Dodaj(){}
}