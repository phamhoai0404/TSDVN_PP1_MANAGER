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

        public const string ERROR_NOT_ADDRESS = "Trong bộ phận: {1} - Vị trí: {0} => Không tồn tại bạn cần kiểm tra lại";
        public const string ERROR_NOT_NULL_INPUT = "{0} => Không được để trống dữ liệu!";
        public const string ERROR_MUST_SELECT_DEPARTMENT = "Cần phải lựa chọn bộ phận!";
        public const string ERROR_MULTI_ADDRESS = "Trong bộ phận: {2} - Vị trí: {0} => Chứa: {1} - bản ghi trong Address  => Bạn cần kiểm tra lại";

        public const string ERROR_VALIDATE_ADDRESS = "Có lỗi phát sinh - địa chỉ ID của Address đang bị lỗi => Bạn có thể tắt chương trình đi mở lại!";
        public const string ERROR_VALIDATE_NOTNULL = "Không được để trống hiệu điện thế và điện trở";

        public const string ERROR_VALIDATE_FORMADDRESS = "Không được để trống địa chỉ khi thêm!";
        public const string ERROR_FORMADDRESS_CHECKEXIST = "Đã tồn tại địa chỉ: {0} => Trong CSDL!";

        public const string ERROR_FORMEXPORT_DATE = "Ngày Từ <= Ngày đến!";
        public const string ERROR_FORMEXPORT_NOTDATA = "Không có dữ liệu thỏa mãn để export!";

        public const string ERROR_IMPORT_SHEETNAME = "SheetName: {0} => Không tồn tại vui lòng kiểm tra lại file import!";
        public const string ERROR_IMPORT_NOT_DEPARTMENT = "Trong file excle row: {0} => Không tồn tại tên bộ phận: {1} !";
        public const string ERROR_IMPORT_NOTNULL_DEPARTMENT = "Trong file excle row: {0} => không được để trống tên bộ phận !";
        public const string ERROR_IMPORT_ADDRESS_DUPPLICATE = "Vị trí: {0} => Đang bị  trùng lặp !";
        public const string ERROR_IMPORT_NOT_DATA= "Không có giá trị trong dữ liệu file import: {0}!";
        
    }
    public class MdlCommon
    {
        public const int NOT_ADDRESS = -1;
        public const int NOT_DEPARTMENT = -1;
    }
}
