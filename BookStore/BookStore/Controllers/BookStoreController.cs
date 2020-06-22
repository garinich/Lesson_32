using System.Linq;
using System.Web.Mvc;
using BusinessLayer;
using BusinessLayer.ModelsDTO;

namespace BookStore.Controllers
{
    public class BookStoreController : Controller
    {
        private readonly BookStoreManager _bookStoreManager;

        public BookStoreController()
        {
            _bookStoreManager = new BookStoreManager();
        }

        public ActionResult Index()
        {
            var books = _bookStoreManager.GetAllBooks();
            return View(books);
        }

        public ActionResult Details(int id)
        {
            var book = _bookStoreManager.GetBookById(id);
            return View(book);
        }

        public ActionResult Delete(int id)
        {
            _bookStoreManager.RemoveBookById(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateBook()
        {
            ViewBag.Categories = new SelectList(_bookStoreManager.GetAllCategories(), "Id", "Name");
            ViewBag.Writers = new SelectList(_bookStoreManager.GetAllWriters(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult CreateBook(BookDTO book)
        {
            _bookStoreManager.AddOrUpdateBook(book);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditBook(int id)
        {
            var book = _bookStoreManager.GetBookById(id);

            ViewBag.Categories = new SelectList(_bookStoreManager.GetAllCategories(), "Id", "Name");
            ViewBag.Writers = new MultiSelectList(_bookStoreManager.GetAllWriters(), "Id", "Name", book.Writers.Select(writer => writer.Id));
            return View(book);
        }

        [HttpPost]
        public ActionResult EditBook(BookDTO book)
        {
            _bookStoreManager.UpdateBook(book);
            return RedirectToAction("Index");
        }

        public ActionResult Categories()
        {
            var categories = _bookStoreManager.GetAllCategories();
            return View(categories);
        }

        public ActionResult CategoryDetails(int id)
        {
            var category = _bookStoreManager.GetCategoryById(id);
            return View(category);
        }

        public ActionResult Writers()
        {
            var writers = _bookStoreManager.GetAllWriters();
            return View(writers);
        }

        public ActionResult WriterDetails(int id)
        {
            var writer = _bookStoreManager.GetWriterById(id);
            return View(writer);
        }
    }
}
