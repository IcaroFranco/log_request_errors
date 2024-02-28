namespace log_request_erros.models;

public sealed class ExampleRequest
{
    public required string Name { get; set; }

    // Como é versão nova, apenas o 'required' já é suficiente.
    // Porém, em versão antiga, pode ser que precise usar o [BindRequired] para a validação funcionar.
    // OBS: Isso em caso de ser INT.
    public required int Age { get; set; }

    public required string Email { get; set; }

    public required string PhoneNumber { get; set; }

    public required string City { get; set; }
}
