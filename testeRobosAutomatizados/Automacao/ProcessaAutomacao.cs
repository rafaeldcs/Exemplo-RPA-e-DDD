
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.IO;
using System.Drawing;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Data;
using DataTable = System.Data.DataTable;
using System.Runtime.InteropServices;
using Workbook = Microsoft.Office.Interop.Excel.Workbook;
using Excel = Microsoft.Office.Interop.Excel;
using OpenQA.Selenium.Firefox;
using FuncoesComuns.Requisicao.Enum;
using OpenQA.Selenium.DevTools;
using FuncoesComuns.Requisicao.Chamada;
using testeRobosAutomatizados.Requisicao.Models;

namespace testeRobosAutomatizados.Automacao
{
    public class ProcessaAutomacao
    {
        public void Automacao()
        {
            int qtdVezes = 1;
            string mensagem = "";


            do
            {
                IWebDriver driver = null;
                try
                {
                    qtdVezes++;

                    var chromeOptions = new ChromeOptions();

                    chromeOptions.AddUserProfilePreference("intl.accept_languages", "nl");
                    chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");

                    driver = new ChromeDriver(chromeOptions);
                    driver.Navigate().GoToUrl("https://www.aec.com.br");
                    driver.Manage().Window.Maximize();
                    Automation(driver);

                    mensagem = "Automação AeC";
                    Console.Write(mensagem);
                    //driver.Quit();
                    break;
                }
                catch (Exception e)
                {

                    // driver.Quit();


                }
            } while (qtdVezes <= 1);
        }

        public static void Automation(IWebDriver driver)
        {

            //CLICA BOTÃO BUSCAR ELEMENTOS
            Thread.Sleep(4000);
            driver.FindElement(By.ClassName("buscar")).Click();
            Thread.Sleep(2000);

            var campoPesquisa = driver.FindElement(By.Name("s"));
            campoPesquisa.Click();
            campoPesquisa.Clear();
            campoPesquisa.SendKeys("Automação");

            driver.FindElement(By.Id("Menu_-_Busca")).Click();
            Thread.Sleep(2000);

            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("scrollBy(0,250)", "");
            Thread.Sleep(2000);

            //SPEECH ANALYTICS
            // driver.FindElement(By.XPath("/html/body/main/div[2]/div/strong/div[1]/div/div/div/a[2]")).Click();
            // System.Threading.Thread.Sleep(1000);

            //jse.ExecuteScript("scrollBy(0,450)", "");
            // System.Threading.Thread.Sleep(2000);

            var publicacao = new Publicacao();

            //TÍTULO
            publicacao.Titulo = driver.FindElement(By.XPath("/html/body/main/div[2]/div/strong/div[1]/div/div/div/a[2]/div[2]/span[1]")).Text;
            Thread.Sleep(1000);

            //ÁREA
            publicacao.Area = driver.FindElement(By.XPath("/html/body/main/div[2]/div/strong/div[1]/div/div/div/a[2]/div[2]/h3")).Text;
            Thread.Sleep(1000);

            //AUTOR
            var autor = driver.FindElement(By.XPath("/html/body/main/div[2]/div/strong/div[1]/div/div/div/a[2]/div[2]/span[2]/small")).Text;
            publicacao.Autor = autor.Substring(13, 15);

            //DESCRIÇÃO
            publicacao.Descricao = driver.FindElement(By.XPath("/html/body/main/div[2]/div/strong/div[1]/div/div/div/a[2]/div[2]/p")).Text;

            //DATA De PUBLICAÇÃO
            var data = driver.FindElement(By.XPath("/html/body/main/div[2]/div/strong/div[1]/div/div/div/a[2]/div[2]/span[2]/small")).Text;
            publicacao.DataPublicacao = data.Substring(30, 11);

            Thread.Sleep(2000);
            //driver.Close();  

            //Salvando dados coletados no site
            var chamarReq = new ChamarRequisicao();
            var reqAutenticacao = chamarReq.FazRequisicao<Publicacao, Publicacao>(publicacao, EnumChamada.Publicacao, HttpMethod.Post);
        }

    }



}
















