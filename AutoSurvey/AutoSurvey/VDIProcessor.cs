using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSurvey
{
    public class VDIProcessor
    {
        public static async Task VdiLogin()
        {
            using (var playwright = await Playwright.CreateAsync())
            {
                await using (var browser = await playwright.Chromium.LaunchAsync(
                    new BrowserTypeLaunchOptions
                    {
                        Headless = false,
                        SlowMo = 50
                    }))
                {
                    var page = await browser.NewPageAsync();
                    await page.GotoAsync(Url.VDIUrl);
                    await page.WaitForTimeoutAsync(10000);
                    await page.ClickAsync("div[class=\"popClose\"]");
                    await page.TypeAsync("input[name=\"loginId\"]", VdiAccount.Username);
                    await page.TypeAsync("input[name=\"mbrPswd\"]", VdiAccount.Username);
                    await page.ClickAsync("text=E-mail");
                    await page.WaitForTimeoutAsync(10000);
                    await page.ClickAsync("button[class=\"btn otp\"]");
                    await page.WaitForTimeoutAsync(10000);
                    page.Dialog += (_, dialog) => dialog.AcceptAsync();
                    await page.WaitForTimeoutAsync(10000);



                }
            }
        }
    }
}
