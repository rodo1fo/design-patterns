using System;
using System.Collections.Generic;
using System.IO;

// Definition: Provide a surrogate or placeholder for another object to control access to it.

namespace Design.Patterns.Structural.ProxySample
{
    interface ThirdPartyYouTubeLib
    {
        List<Stream> listVideos();
        string getVideoInfo(int id);
        Stream downloadVideo(int id);
    }

    class ThirdPartyYouTubeClass : ThirdPartyYouTubeLib
    {
        public List<Stream> listVideos()
        {
            return null;
        }

        public string getVideoInfo(int id)
        {
            return string.Empty;
        }

        public Stream downloadVideo(int id)
        {
            return Stream.Null;
        }
    }

    class CachedYouTubeClass : ThirdPartyYouTubeLib
    {
        private readonly ThirdPartyYouTubeLib _service;
        private List<Stream> _listCache;
        private string _videoCache;

        public CachedYouTubeClass(ThirdPartyYouTubeLib service)
        {
            _service = service;
        }

        public List<Stream> listVideos()
        {
            if (_listCache == null)
                _listCache = _service.listVideos();
            return _listCache;
        }

        public string getVideoInfo(int id)
        {
            if (_videoCache == null)
                _videoCache = _service.getVideoInfo(id);
            return _videoCache;
        }

        public Stream downloadVideo(int id)
        {
            var fileIndex = FindFileIndex(id);
            if (fileIndex != -1)
                _service.downloadVideo(id);

            return _listCache[fileIndex];
        }

        // find index on cacheList
        private static int FindFileIndex(int id)
        {
            return 0;
        }
    }

    class YouTubeManager
    {
        private readonly ThirdPartyYouTubeLib _service;

        public YouTubeManager(ThirdPartyYouTubeLib service)
        {
            _service = service;
        }

        private string RenderVideoPage(int id)
        {
            return _service.getVideoInfo(id);
        }

        private List<Stream> RenderListPanel()
        {
            return _service.listVideos();
        }

        public void reactOnUserInput(int id)
        {
            RenderVideoPage(id);
            RenderListPanel();
        }
    }

    class TestProxy
    {
        static void Run()
        {
            Console.WriteLine("***Proxy Pattern Demo***\n");

            var youtubeService = new ThirdPartyYouTubeClass();
            var proxy = new CachedYouTubeClass(youtubeService);

            const int videoId = 10;
            
            var manager = new YouTubeManager(proxy);
            manager.reactOnUserInput(videoId);
                
            Console.ReadKey();
        }
    }
}