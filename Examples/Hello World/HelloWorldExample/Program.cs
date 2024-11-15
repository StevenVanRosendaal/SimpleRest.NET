﻿using SimpleRest.Api;
using SimpleRest.Handlers;

public class Program
{
    static async Task Main()
    {
        SimpleRestApi api = new SimpleRestApi(3000, new SimpleRestLogger(SimpleRestLogLevel.DEBUG));
        api.Use(new CorsHandler());
        api.Use(new ResourceNotFoundHandler());

        api.Get(
            "/",
            async (req, res) =>
            {
                res.Send("HelloWorld");
            }
        );
        await api.Start(
            (port, url) =>
            {
                Console.WriteLine("Server started: " + url);
            }
        );
    }
}
