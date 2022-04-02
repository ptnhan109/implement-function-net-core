using AutoSurvey.Enums;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSurvey
{
    public class RollUpProcessor
    {
        public static async Task RollUp(EnumCheckOutTypes types)
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
                    await page.GotoAsync(Url.SurveyUrl);
                    await page.WaitForTimeoutAsync(10000);

                    await page.TypeAsync("input[name=\"loginfmt\"]", MicrosoftAccount.Username);
                    await page.ClickAsync("input[type=\"submit\"]");

                    await page.WaitForTimeoutAsync(10000);

                    await page.TypeAsync("input[name=\"passwd\"]", MicrosoftAccount.Password);
                    await page.ClickAsync("input[type=\"submit\"]");

                    await page.WaitForTimeoutAsync(5000);

                    await page.ClickAsync("input[class=\"win-button button-secondary button ext-button secondary ext-secondary\"]");
                    await page.WaitForTimeoutAsync(3000);

                    switch (types)
                    {
                        case EnumCheckOutTypes.MorningCheckIn:
                            await page.ClickAsync(":nth-match(:text('Check in'), 5)");
                            break;
                        case EnumCheckOutTypes.MorningCheckOut:
                            await page.ClickAsync(":nth-match(:text('Check out'), 3)");
                            break;
                        case EnumCheckOutTypes.AfternoonCheckIn:
                            await page.ClickAsync(":nth-match(:text('Check in'), 6)");
                            break;
                        case EnumCheckOutTypes.AfternoonCheckOut:
                            await page.ClickAsync(":nth-match(:text('Check out'), 4)");
                            break;
                        default:
                            break;
                    }

                    await page.ClickAsync("text=Yes");
                    await page.ClickAsync("text=CMC Tower");
                    await page.ClickAsync("text=SVPN");
                    await page.ClickAsync("text=Submit");

                    await page.WaitForTimeoutAsync(30000);

                }
            }
        }
    }
}
