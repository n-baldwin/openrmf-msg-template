using Xunit;
using System;
using System.Threading.Tasks;
using openrmf_msg_template.Models;
using openrmf_msg_template.Data;
using Microsoft.Extensions.Options;
using MongoDB.Bson;

namespace tests.Data
{
    public class TemplateRepositoryTests
    {
        private readonly TemplateRepository _templateRepository;

        public TemplateRepositoryTests()
        {
            Settings settings = new Settings();

            settings.ConnectionString = "mongodb://openrmftemplate:openrmf1234!@localhost/openrmftemplate?authSource=admin";
            settings.Database = "openrmftemplate";

            _templateRepository = new TemplateRepository(settings);
        }

        [Fact]
        public async Task Test_TemplateRepositoryIsValid()
        {
            Template template = new Template();
            ObjectId objId = ObjectId.GenerateNewId();

            template.InternalId = objId;

            // Testing
            await _templateRepository.GetTemplateByTitle("title");
            await _templateRepository.GetTemplateByFilename("filename");
        }
    }
}
