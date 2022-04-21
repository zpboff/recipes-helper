﻿using Core.RabbitMQ;

namespace Recipes.API.Settings;

public class RecipesRabbitSettings: IRabbitSettings
{
    public string Host { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
}