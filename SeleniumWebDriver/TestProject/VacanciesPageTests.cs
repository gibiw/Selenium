using NUnit.Framework;
using Pages;
using Utils;

namespace TestProject
{
    public class VacanciesPageTests
    {
        private VacanciesPage _page;

        [SetUp]
        public void Setup()
        {
            Browser.Initialize();

            _page = new VacanciesPage();
        }

        [TestCase("Разработка продуктов", "Английский", 7)]
        public void CheckVacanciesCount(string departmentName, string language, int expectedCount)
        {
            _page.OpenPage();
            _page.SelectDepartment(departmentName);
            _page.SelectLanguage(language);
            var vacanciesCount = _page.GetVacanciesCount();

            Assert.AreEqual(expectedCount, vacanciesCount);
        }

        [TearDown]
        public void Cleanup()
        {
            Browser.Shutdown();
        }
    }
}