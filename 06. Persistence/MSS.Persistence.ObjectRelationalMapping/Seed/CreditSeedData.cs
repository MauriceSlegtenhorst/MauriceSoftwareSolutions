using DomainCredit = MSS.Domain.Concrete.DatabaseEntities.Credit.Credit;

using System;


namespace MSS.Persistence.ObjectRelationalMapping.Credit
{
    internal sealed class CreditSeedData

    {
        private CreditSeedData() { }

        internal static DomainCredit[] Build()
        {
            return new DomainCredit[]
            {
                new DomainCredit
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Syncfusion",
                    SubTitle = "Easy to use premade Blazor components",
                    LinkToImage = "https://cdn.syncfusion.com/content/images/Logo/Logo_150dpi.png",
                    HTMLGotFrom = "Got from: <a href='https://www.syncfusion.com/products/communitylicense'>Syncfusion community license</a>",
                    HTMLMadeBy = "Made by: <a href='https://www.syncfusion.com/blazor-components'>Syncfusion website</a>",
                    HTMLDescription = "<p>Some tasks while creating an UI are repetative. Syncfusion helps by providing components for repetative use.</p>"
                },
                new DomainCredit
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Open Iconic",
                    SubTitle = "Provider of fonts and icons",
                    LinkToImage = "https://img.stackshare.io/service/3029/iconic.png",
                    HTMLGotFrom ="<a href='https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor'>Blazor WebAssembly project builder</a>",
                    HTMLMadeBy = "<a href='https://useiconic.com/open'>Open-Iconic</a>",
                    HTMLDescription = "<p>Most, if not all icons came from this provider. This font came with the project when it was created. I kept it for its ease of use.</p>"
                },
                new DomainCredit
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Tim Corey",
                    SubTitle = "Youtuber with the best C# tuturials",
                    LinkToImage = "https://avatars3.githubusercontent.com/u/1839873?s=400&v=4",
                    HTMLGotFrom = "Searching for tutorial video's on <a href='https://www.youtube.com'>YouTube</a> about C#",
                    HTMLMadeBy = "<a href='https://www.youtube.com/timcorey'>Tim Corey's YouTube channel</a>",
                    HTMLDescription = "<p>Tim Corey provides many educational video's and tutorials about programming. His content is focused on C# but he covers other " +
                    "languages too. His goal is to make learning C# easier. Awesome guy.</p>"
                },
                new DomainCredit
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Pluralsight",
                    SubTitle = "Best educational video streaming service",
                    LinkToImage = "https://pbs.twimg.com/profile_images/1291779527576653824/vifRmgyc.jpg",
                    HTMLGotFrom = "ITvitae giving me an account on <a href='https://www.pluralsight.com/'>Pluralsight</a>",
                    HTMLMadeBy = "<a href='https://www.pluralsight.com/content/pluralsight/en/about/jcr:content/main/generic_block_167843627/parsys/columns/column-parsys-1/executive/parsys/executive_member/gridimage-res.img.75734133-ac30-41ab-8e2a-4b7033ca7e10.jpg'>CEO Aaron Skonnard</a>",
                    HTMLDescription = "<p>Pluralsight has helped me better understand software architecture and desighn patterns. The video's are very thorough and helpfull. " +
                    "One thing is that there is so much info that sometimes it takes long to find something specific.</p>"
                }
            };
        }
    }
}
