using ConsoleApp.Contexts;
using ConsoleApp.Entities;

namespace ConsoleApp.Repositories;

internal class AddressRepository : Repo<AddressEntity>
{
    public AddressRepository(DataContext context) : base(context)
    {

    }
}
