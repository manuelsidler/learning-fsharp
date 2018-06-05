namespace Capstone2.Domain

type Customer = { Name: string }
type Account = { CurrentBalance: decimal; Id: System.Guid; Customer: Customer }