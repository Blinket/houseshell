using HouseShell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseShell.Services
{
    public class HouseDataStore : IDataStore<House>
    {
        int id = 1;
        readonly List<House> houses;
        public HouseDataStore()
        {
            houses = GetHouses();
        }

        private List<House> GetHouses()
        {
            List<House> houses = new List<House>
            {
                new House{ ID = NewID(), Address1 = "15 Crows Nest Pl", City = "New Jack", HouseType = "Cape Cod", ListedBy = "Shmenge Brothers", ImageUrl="cape01.jpg"},
                new House{ ID = NewID(), Address1 = "43 Croton Hill Rd", City = "New Jack", HouseType = "Cape Cod", ListedBy = "Shmenge Brothers", ImageUrl="cape02.jpg"},
                new House{ ID = NewID(), Address1 = "8 Crim Dr", City = "New Jack", HouseType = "Cape Cod", ListedBy = "Shmenge Brothers", ImageUrl="cape03.jpg"},
                new House{ ID = NewID(), Address1 = "45 Crim Dr", City = "New Jack", HouseType = "Colonial", ListedBy = "McParrot Realty", ImageUrl="colonial01.jpg"},
                new House{ ID = NewID(), Address1 = "78 Corrine St", City = "New Jack", HouseType = "Colonial", ListedBy = "McParrot Realty", ImageUrl="colonial02.jpg"},
                new House{ ID = NewID(), Address1 = "11 West North St", City = "New Jack", HouseType = "Cottage", ListedBy = "McParrot Realty", ImageUrl="cottage1.jpg"},
                new House{ ID = NewID(), Address1 = "111 Esplanade Dr", City = "New Jack", HouseType = "Ranch", ListedBy = "Clown/Banker LLC", ImageUrl="ranch01.jpg"},
                new House{ ID = NewID(), Address1 = "56 Fraln Blvd", City = "New Jack", HouseType = "Ranch", ListedBy = "Clown/Banker LLC", ImageUrl="ranch02.jpg"},
                new House{ ID = NewID(), Address1 = "33 Goose Ln", City = "New Jack", HouseType = "Ranch", ListedBy = "Clown/Banker LLC", ImageUrl="ranch03.jpg"}
            };

            return houses;
        }
        private string NewID()
        {
            return (id++).ToString();
        }

        public Task<bool> AddItemAsync(House item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<House> GetItemAsync(string id)
        {
            return await Task.FromResult(houses.FirstOrDefault(s => s.ID == id));
        }

        public async Task<IEnumerable<House>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(houses);
        }

        public Task<bool> UpdateItemAsync(House item)
        {
            throw new NotImplementedException();
        }
    }
}
