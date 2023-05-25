using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_MAIN.DTO
{
    public class RESULT
    {
        public const string OK = "OK";
        public const string ERROR_HAS_DATA = "HAS_DATA";

        public const string ERROR_015_CATCH = "Lỗi {0} Catch - {1}";


        public const string ERROR_NOT_ADDRESS = "Vị trí: {0} => Không tồn tại bạn cần kiểm tra lại";
        public const string ERROR_NOT_NULL_INPUT = "{0} => Không được để trống dữ liệu!";
        public const string ERROR_MULTI_ADDRESS = "Vị trí: {0} => Chứa: {0} - bản ghi trong Address  => Bạn cần kiểm tra lại";

    }
}
