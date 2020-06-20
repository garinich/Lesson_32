// ShopController

		[HttpGet]
        public ActionResult CreateProduct()
        {
            var groups = _shopManager.GetAllGroups();
            return View(groups);
        }

        [HttpPost]
        public ActionResult CreateProduct(ProductDTO productDto)
        {
            _shopManager.AddProduct(productDto);
            return RedirectToAction("Index");
        }

// ShopManager

        public IList<GroupDTO> GetAllGroups()
        {
            return _mapper.Map<IList<GroupDTO>>(_shopRepo.GetAllGroups());
        }
        
        public void AddProduct(ProductDTO productDto)
        {
            var group = _mapper.Map<GroupDTO>(_shopRepo.GetGroupById(productDto.GroupId));
            productDto.Groups.Add(group);
            _shopRepo.SaveProduct(_mapper.Map<Product>(productDto));
        }

// ShopRepo

        public void SaveProduct(Product product)
        {
            using (var ctx = new ShopContext())
            {
                ctx.Products.Add(product);

                ctx.SaveChanges();
            }
        }