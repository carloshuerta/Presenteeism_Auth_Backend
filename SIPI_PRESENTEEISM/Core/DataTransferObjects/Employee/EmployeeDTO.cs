﻿namespace SIPI_PRESENTEEISM.Core.DataTransferObjects.Employee
{
    using SIPI_PRESENTEEISM.Core.DataTransferObjects.Zone;
    using SIPI_PRESENTEEISM.Core.Domain.Enums;

    public class EmployeeDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public ZoneDTO Zone { get; set; }

        public List<string> ImagesToIdentify { get; set; }

        public int ValidationCode { get; set; }

        public EmployeeState State { get; set; }

        public EmployeeDTO() { }

        public EmployeeDTO(Domain.Entities.Employee entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            LastName = entity.LastName;
            Email = entity.Email;
            Zone = new ZoneDTO()
            {
                Name = entity.Zone.Name,
                RadioKm = entity.Zone.RadioKm,
                Latitude = entity.Zone.Latitude,
                Longitude = entity.Zone.Longitude
            };
            ImagesToIdentify = entity.ImagesToIdentify?
                .Select(image => image.ImageURL)
                .ToList();
            ValidationCode = entity.ValidationCode;
            State = entity.State;
        }
    }
}
