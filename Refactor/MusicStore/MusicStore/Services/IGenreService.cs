using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Services
{
    public interface IGenreService : IDisposable
    {
        Genre FindGenreByName(string genreName);
        IEnumerable<Genre> FindGenres();
    }
}
