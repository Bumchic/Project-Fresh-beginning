//public class SpeedBoostItem : MonoBehaviour
//{
//    public float boostDuration = 5f; // Thời gian hiệu lực của tăng tốc
//    private bool isPickedUp = false;

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player") && !isPickedUp)
//        {
//            Player player = other.GetComponent<Player>();
//            if (player != null)
//            {
//                // Kích hoạt tăng tốc trong trạng thái chạy của người chơi
//                player.runningState.ActivateSpeedBoost();

//                // Bắt đầu coroutine để hủy bỏ tăng tốc sau một khoảng thời gian
//                StartCoroutine(DeactivateBoostAfterTime(player));

//                // Đánh dấu item đã được nhặt
//                isPickedUp = true;

//                // Tùy chọn: xóa hoặc vô hiệu hóa item sau khi nhặt
//                Destroy(gameObject, 0.5f); // Đợi cho animation nhặt hoàn thành
//            }
//        }
//    }

//    private IEnumerator DeactivateBoostAfterTime(Player player)
//    {
//        yield return new WaitForSeconds(boostDuration);
//        player.runningState.DeactivateSpeedBoost(); // Hủy bỏ tăng tốc
//    }
//}
