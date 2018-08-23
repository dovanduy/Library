﻿using ModelsClassLibrary.MenuNS;
using ModelsClassLibrary.ModelsNS.ProductChildNS;
using ModelsClassLibrary.ModelsNS.ProductNS;
using ModelsClassLibrary.ModelsNS.SharedNS;
using UserModels;

namespace ModelsClassLibrary.ModelsNS.LikeUnlikeNS
{
    public class LikeUnlike : CommonWithId
    {
        public LikeUnlike()
        {

        }

        public void Initialize(string menuPath1Id, string menuPath2Id, string menuPath3Id, string productId, string productChildId, string userId, bool isLike, string comment)
        {
            MenuPath1Id = menuPath1Id;
            MenuPath2Id = menuPath2Id;
            MenuPath3Id = menuPath3Id;
            ProductId = productId;
            ProductChildId = productChildId;
            UserId = userId;
            IsLike = isLike;
            Name = KeyGenerator();
            Comment = comment;
        }

        public string MenuPath1Id { get; set; }
        public virtual MenuPath1 MenuPath1 { get; set; }


        public string MenuPath2Id { get; set; }
        public virtual MenuPath2 MenuPath2 { get; set; }

        public string MenuPath3Id { get; set; }
        public virtual MenuPath3 MenuPath3 { get; set; }

        public string ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string ProductChildId { get; set; }
        public virtual ProductChild ProductChild { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public bool IsLike { get; set; }

        /// <summary>
        /// This creates a key from the Ids
        /// </summary>
        /// <param name="menuPath1Id"></param>
        /// <param name="menuPath2Id"></param>
        /// <param name="menuPath3Id"></param>
        /// <param name="productId"></param>
        /// <param name="productChildId"></param>
        /// <returns></returns>
        public string KeyGenerator(string menuPath1Id, string menuPath2Id, string menuPath3Id, string productId, string productChildId, string userId, bool isLike)
        {
            return string.Format("{0}{1}{2}{3}{4}{5}", isLike, userId, menuPath1Id, menuPath2Id, menuPath3Id, productId, productChildId);
        }
        public string KeyGenerator()
        {
            return KeyGenerator(MenuPath1Id, MenuPath2Id, MenuPath3Id, ProductId, ProductChildId, UserId, IsLike);
        }


        public override EnumLibrary.EnumNS.ClassesWithRightsENUM ClassNameForRights()
        {
            return EnumLibrary.EnumNS.ClassesWithRightsENUM.LikeUnlike;
        }

    }
}
