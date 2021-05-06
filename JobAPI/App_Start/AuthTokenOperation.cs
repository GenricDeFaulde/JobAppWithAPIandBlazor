using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobAPI.App_Start
{
    public class AuthTokenOperation : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Paths.Add("/_token", new OpenApiPathItem
            {
                Operations = new Dictionary<OperationType, OpenApiOperation>
                {
                    [OperationType.Post] = new OpenApiOperation
                    {
                        Tags = new List<OpenApiTag>
                        {
                           new OpenApiTag {Name = "Auth"},
                           new OpenApiTag {Description = "Authorization" }
                        },
                        Parameters = new List<OpenApiParameter>
                        {
                            new OpenApiParameter
                            {
                                Name = "grant_type",
                                Required = true,
                                In = ParameterLocation.Header,
                                Content = new Dictionary<string, OpenApiMediaType> {
                                    {
                                        "application/url-www-form-encoded",
                                        new OpenApiMediaType()
                                        {
                                            Schema = context.SchemaGenerator
                                            .GenerateSchema(typeof(string), context.SchemaRepository)
                                        }
                                    }
                                }
                            },
                            new OpenApiParameter
                            {
                                Name = "username",
                                Required = false,
                                In = ParameterLocation.Header,
                                Content = new Dictionary<string, OpenApiMediaType> {
                                    {
                                        "application/url-www-form-encoded",
                                        new OpenApiMediaType()
                                        {
                                            Schema = context.SchemaGenerator
                                            .GenerateSchema(typeof(string), context.SchemaRepository)
                                        }
                                    }
                                }
                            },
                            new OpenApiParameter
                            {
                                Name = "password",
                                Required = false,
                                In = ParameterLocation.Header,
                                Content = new Dictionary<string, OpenApiMediaType> {
                                    {
                                        "application/url-www-form-encoded",
                                        new OpenApiMediaType()
                                        {
                                            Schema = context.SchemaGenerator
                                            .GenerateSchema(typeof(string), context.SchemaRepository)
                                        }
                                    }
                                }
                            }

                        }

                    }
                }
            });
        }
    }
}

