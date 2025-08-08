using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System.Linq;

namespace BuilderDesignPattern
{
    internal class Resume
    {
        private string firstName;
        private string lastName;
        private string address;
        private string email;
        private string phone;

        private string[] education;
        private string[] skills;
        private string[] experience;

        public Resume AddName(string firstName, string lastName)
        {
            this.lastName = lastName;
            this.firstName = firstName;

            return this;
        } 

        public Resume AddEmail(string email)
        {
            this.email = email;
            return this;
        }

        public Resume AddPhone(string phone) 
        {
            this.phone = phone;
            return this;
        }

        public Resume AddAddress(string address) 
        { 
            this.address = address;
            return this;
        }

        public Resume AddEducation(string education)
        {
            if(this.education == null)
            {
                this.education = new string[] { };
            }
            this.education.Append(education);
            return this;
        }

        public Resume AddExperience(string experience)
        {
            if (this.experience == null)
            {
                this.experience = new string[] { };
            }
            this.experience.Append(experience);
            return this;
        }

        public Resume AddSkills(string skills)
        {
            if (this.skills == null)
            {
                this.skills = new string[] { };
            }
            this.skills.Append(skills);
            return this;
        }

        public void Build()
        {
            var pdf = new Document();
            PdfWriter.GetInstance(pdf, File.Create("resume.pdf"));
            pdf.Open();
            pdf.NewPage();
            var paraFont = new Font(Font.FontFamily.HELVETICA, 16f);
            var header = this.firstName + "  " + this.lastName + "      " + this.email + "/" + this.phone;
            var para = new Paragraph(header, paraFont);
            pdf.Add(para);
            pdf.Add(Chunk.NEWLINE);
            pdf.Add(new LineSeparator());
            pdf.Add(Chunk.NEWLINE);

            pdf.Add(new Paragraph("Address", paraFont));
            pdf.Add(new Phrase(this.address));
            pdf.Add(Chunk.NEWLINE);
            pdf.Add(Chunk.NEWLINE);

            pdf.Add(new Paragraph("Education", paraFont));
            foreach (var edu in this.education)
            {
                pdf.Add(new Phrase(edu));
            }
            pdf.Add(Chunk.NEWLINE);
            pdf.Add(Chunk.NEWLINE);

            pdf.Add(new Paragraph("Skills", paraFont));
            foreach (var skill in skills)
            {
                pdf.Add(new Phrase(skill));
                pdf.Add(Chunk.NEWLINE);
            }
            pdf.Add(Chunk.NEWLINE);

            pdf.Add(new Paragraph("Experience", paraFont));
            foreach (var exp in experience)
            {
                pdf.Add(new Phrase(exp));
                pdf.Add(Chunk.NEWLINE);
            }
            pdf.Add(Chunk.NEWLINE);

            pdf.Close();

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Builder Design Pattern");
            Resume resume = new Resume();
            resume.AddName("Deven", "Mhatre");
            resume.AddPhone("7011111111");
            resume.AddEmail("deven..gmail.com");
            
            resume.AddAddress("Chunabhatti Mumbai 400022");
            
            resume.AddExperience("BentleySystems");
            
            resume.AddEducation("BE");
            resume.AddEducation("PG-DAC");

            resume.AddSkills("C#");
            resume.AddSkills("Javascript");
            resume.AddSkills("React");

            resume.Build();
        }
    }
}
