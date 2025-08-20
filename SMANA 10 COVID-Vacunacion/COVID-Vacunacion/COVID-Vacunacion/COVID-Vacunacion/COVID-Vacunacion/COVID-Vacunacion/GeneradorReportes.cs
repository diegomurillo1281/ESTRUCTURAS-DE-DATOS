using System;
using System.Collections.Generic;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace COVID_Vacunacion
{
    public class GeneradorReportes
    {
        public void GenerarReporteCompleto(OperacionesConjuntos operaciones)
        {
            using (var writer = new PdfWriter("Reporte_Vacunacion_COVID.pdf"))
            using (var pdf = new PdfDocument(writer))
            {
                var document = new Document(pdf);
                document.Add(new Paragraph("REPORTE OFICIAL - CAMPAÑA DE VACUNACIÓN COVID-19")
                    .SetTextAlignment(TextAlignment.CENTER).SetFontSize(18).SetBold().SetMarginBottom(20));
                
                document.Add(new Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm:ss}"));
                document.Add(new Paragraph("Ministerio de Salud - Gobierno Nacional\n"));

                AgregarEstadisticas(document, operaciones);
                AgregarListado(document, "CIUDADANOS NO VACUNADOS", operaciones.NoVacunados);
                AgregarListado(document, "CIUDADANOS CON AMBAS DOSIS", operaciones.AmbasDosis);
                AgregarListado(document, "CIUDADANOS SOLO CON PFIZER", operaciones.SoloPfizer);
                AgregarListado(document, "CIUDADANOS SOLO CON ASTRAZENECA", operaciones.SoloAstraZeneca);
            }
        }

        private void AgregarEstadisticas(Document document, OperacionesConjuntos operaciones)
        {
            Table tabla = new Table(2).UseAllAvailableWidth();
            tabla.AddHeaderCell(new Cell().Add(new Paragraph("ESTADÍSTICA").SetBold()));
            tabla.AddHeaderCell(new Cell().Add(new Paragraph("CANTIDAD").SetBold()));

            string[] estadisticas = { "Total ciudadanos", "No vacunados", "Ambas dosis", "Solo Pfizer", "Solo AstraZeneca" };
            int[] valores = { operaciones.TodosCiudadanos.Count, operaciones.NoVacunados.Count, 
                            operaciones.AmbasDosis.Count, operaciones.SoloPfizer.Count, operaciones.SoloAstraZeneca.Count };

            for (int i = 0; i < estadisticas.Length; i++)
            {
                tabla.AddCell(new Cell().Add(new Paragraph(estadisticas[i])));
                tabla.AddCell(new Cell().Add(new Paragraph(valores[i].ToString())));
            }

            document.Add(tabla);
            document.Add(new Paragraph(" "));
        }

        private void AgregarListado(Document document, string titulo, List<Ciudadano> ciudadanos)
        {
            document.Add(new Paragraph(titulo).SetBold().SetFontSize(14).SetMarginTop(20).SetMarginBottom(10));
            
            Table tabla = new Table(4).UseAllAvailableWidth();
            tabla.AddHeaderCell(new Cell().Add(new Paragraph("CÉDULA").SetBold()));
            tabla.AddHeaderCell(new Cell().Add(new Paragraph("NOMBRE").SetBold()));
            tabla.AddHeaderCell(new Cell().Add(new Paragraph("EDAD").SetBold()));
            tabla.AddHeaderCell(new Cell().Add(new Paragraph("CIUDAD").SetBold()));

            foreach (var ciudadano in ciudadanos)
            {
                tabla.AddCell(new Cell().Add(new Paragraph(ciudadano.Cedula)));
                tabla.AddCell(new Cell().Add(new Paragraph(ciudadano.NombreCompleto)));
                tabla.AddCell(new Cell().Add(new Paragraph(ciudadano.Edad.ToString())));
                tabla.AddCell(new Cell().Add(new Paragraph(ciudadano.Ciudad)));
            }

            document.Add(tabla);
        }
    }
}
