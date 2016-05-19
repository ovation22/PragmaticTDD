using System.Linq;
using System.Web.Mvc;
using Pragmatic.TDD.Services.Interfaces;
using Pragmatic.TDD.Web.Interfaces;

namespace Pragmatic.TDD.Web.Controllers
{
    public class HorsesController : Controller
    {
        private readonly IHorseService _horseService;
        private readonly IMapper<Dto.Horse, Models.HorseDetail> _horseDetailMapper;
        private readonly IMapper<Dto.Horse, Models.HorseSummary> _horseSummaryMapper;

        public HorsesController(IHorseService horseService, 
            IMapper<Dto.Horse, Models.HorseDetail> horseDetailMapper, 
            IMapper<Dto.Horse, Models.HorseSummary> horseSummaryMapper)
        {
            _horseService = horseService;
            _horseDetailMapper = horseDetailMapper;
            _horseSummaryMapper = horseSummaryMapper;
        }

        public ActionResult Index()
        {
            var horses = _horseService.GetAll();

            var model = horses.Select(_horseSummaryMapper.Map).ToList();

            return View(model);
        }

        public ActionResult Horse(int id)
        {
            var horse = _horseService.Get(id);

            var model = _horseDetailMapper.Map(horse);

            return View(model);
        }
    }
}