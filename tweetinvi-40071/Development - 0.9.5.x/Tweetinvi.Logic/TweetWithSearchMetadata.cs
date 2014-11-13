﻿using Tweetinvi.Core.Helpers;
using Tweetinvi.Core.Injectinvi;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Interfaces.Controllers;
using Tweetinvi.Core.Interfaces.DTO;
using Tweetinvi.Core.Interfaces.Factories;

namespace Tweetinvi.Logic
{
    public class TweetWithSearchMetadata : Tweet, ITweetWithSearchMetadata
    {
        private ITweetWithSearchMetadataDTO _tweetWithSearchMetadataDTO;

        public TweetWithSearchMetadata(
            ITweetWithSearchMetadataDTO tweetDTO, 
            ITweetController tweetController, 
            ITweetFactory tweetFactory, 
            IUserFactory userFactory, 
            ITaskFactory taskFactory, 
            IFactory<IMedia> mediaFactory) 
            : base(tweetDTO, tweetController, tweetFactory, userFactory, taskFactory, mediaFactory)
        {
            _tweetWithSearchMetadataDTO = tweetDTO;
        }

        public ITweetFromSearchMetadata SearchMetadata
        {
            get { return _tweetWithSearchMetadataDTO.TweetFromSearchMetadata; }
        }
    }
}
