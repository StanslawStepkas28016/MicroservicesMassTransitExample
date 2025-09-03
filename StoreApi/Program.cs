using ConsumerApi.Configuration;
using ConsumerApi.Consumers;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Configure MassTransit in conjunction with RabbitMQ.
builder.Services.AddMassTransit
(busConfig =>
    {
        busConfig.SetKebabCaseEndpointNameFormatter();

        // Add all created consumers.
        busConfig.AddConsumer<OrderCreatedConsumer>();

        busConfig.UsingRabbitMq
        ((context, config) =>
            {
                RabbitMqSettings? settings = builder.Configuration.GetSection
                    (nameof(RabbitMqSettings)).Get<RabbitMqSettings>();

                config.Host
                (
                    settings!.Host, "/", h =>
                    {
                        h.Username(settings.Username);
                        h.Password(settings.Password);
                    }
                );

                config.ConfigureEndpoints(context);
            }
        );
    }
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();