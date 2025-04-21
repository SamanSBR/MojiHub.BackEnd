namespace MojiHub.BackEnd.Utility
{
    public class EmailBodyBuilder
    {
        public static string BuildActivationEmail(string userName, string activationLink)
        {
            
            return $@"
<!DOCTYPE html>
<html lang='fa' dir='rtl'>
<head>
    <meta charset='UTF-8'>
    <title>فعال‌سازی حساب کاربری</title>
</head>
<body style='font-family:Tahoma; direction:rtl; text-align:center; background-color:#f9f9f9; padding:2rem;'>
    <div style='max-width:600px; margin:auto; background:#fff; padding:2rem; border-radius:1rem; box-shadow:0 0 15px rgba(0,0,0,0.05);'>
        <h2 style='color:#212529;'>سلام {userName} عزیز 👋</h2>
        <p style='font-size:1.1rem; color:#555;'>برای فعال‌سازی حساب کاربری خود در <strong>MojiHub</strong>، لطفاً روی دکمه زیر کلیک کن:</p>
        <a href='{activationLink}' style='display:inline-block; background-color:#0d6efd; color:#fff; padding:0.8rem 1.5rem; border-radius:0.5rem; margin-top:1rem; text-decoration:none;'>فعال‌سازی حساب</a>
        <p style='margin-top:2rem; font-size:0.9rem; color:#888;'>اگر این ایمیل برای شما نبوده، لطفاً آن را نادیده بگیرید.</p>
        <p style='font-size:0.9rem; color:#888;'>با احترام، تیم MojiHub ❤️</p>
    </div>
</body>
</html>";
        }
    }
}

