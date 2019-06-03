using IndieVisible.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.Core.Models
{
    public abstract class ExternalEntity : Entity
    {
        #region ExternalHandles
        public string GameJoltUrl { get; set; }

        public string ItchIoUrl { get; set; }

        public string IndieDbUrl { get; set; }

        public string GameDevNetUrl { get; set; }

        public string UnityConnectUrl { get; set; }
        #endregion
    }
}
