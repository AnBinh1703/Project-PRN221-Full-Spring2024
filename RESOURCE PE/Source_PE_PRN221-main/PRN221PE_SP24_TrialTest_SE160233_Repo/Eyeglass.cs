
namespace PRN221PE_SP24_TrialTest_SE160233_Repo
{
    public partial class Eyeglass
    {
        public int EyeglassesId { get; set; }
        public string EyeglassesName { get; set; } = null!;
        public string? EyeglassesDescription { get; set; }
        public string? FrameColor { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LensTypeId { get; set; }

        public virtual LensType? LensType { get; set; }
    }
}
