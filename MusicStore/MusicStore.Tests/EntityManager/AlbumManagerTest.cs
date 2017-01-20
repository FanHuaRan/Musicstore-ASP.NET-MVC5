using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore.EntityManager;
using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Tests.EntityManager
{
    [TestClass]
    public class AlbumManagerTest
    {
        AlbumManager albumManager = new AlbumManager();

        [TestMethod]
        public void FindById(long id)
        {
           Album album= albumManager.FindById(1);
           Assert.AreEqual("The Best Of Men At Work", album.Title);
        }
    }
}
