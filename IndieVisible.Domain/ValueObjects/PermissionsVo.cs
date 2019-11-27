namespace IndieVisible.Domain.ValueObjects
{
    public class PermissionsVo
    {
        public bool CanEdit { get; set; }

        public bool CanDelete { get; set; }

        public bool CanPostActivity { get; set; }

        public bool CanFollow { get; set; }

        public bool CanConnect { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsMe { get; set; }
    }
}