using System;
using Utils;

namespace Pages
{
    public class VacanciesPage
    {
        private const string Url = "https://careers.veeam.ru/vacancies";
        private const string AllDepartmentButton = "//body//button[text()=\"Все отделы\"]";
        private const string AllLanguageButton = "//body//button[text()=\"Все языки\"]";
        private const string VacancyCard = "//a[contains(@class,\"card\")]";

        public void OpenPage()
        {
            Browser.OpenUrl(Url);

            if (!IsPageOpened())
            {
                throw new ApplicationException("Page not opened!");
            }
        }

        public void SelectDepartment(string departmentName)
        {
            Browser.Click(AllDepartmentButton);
            Browser.Click(DepartmentSelector(departmentName));
        }

        public void SelectLanguage(string language)
        {
            Browser.Click(AllLanguageButton);
            Browser.Click(LanguageSelector(language));
        }

        public int GetVacanciesCount()
        {
            var vacancies = Browser.GetElements(VacancyCard);

            return vacancies.Count;
        }

        private string DepartmentSelector(string departmentName) => $"//a[text()=\"{departmentName}\"]";
        private string LanguageSelector(string language) => $"//*[contains(@class,\"checkbox\") and ./*[text()=\"{language}\"]]";

        private bool IsPageOpened()
        {
            var currentUrl = Browser.GetCurrentUrl();

            return Url.Equals(currentUrl, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}