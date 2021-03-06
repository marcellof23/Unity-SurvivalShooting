# IF3210-2022-Unity-03

## Deskripsi Aplikasi
Game "Pooja Shooter" merupakan sebuah game 3D Survival Shooter, dimana pemain akan berusaha untuk bertahan hidup melawan serangan dari monster - monster yang ada di dalam game. Game ini memiliki 2 buah mode permainan, yaitu **Zen Mode** dan **Wave Mode**, dimana di dalam zen mode, skor pemain akan dihitung dari seberapa lama pemain dapat bertahan hidup, sedangkan untuk wave mode, skor pemain akan dihitung dari skor total yang diperoleh saat mengalahkan musuh serta wave terjauh yang dapat dicapai oleh pemain.

Dalam game ini, pemain juga dapat memperoleh **Power Up** berupa **Orb** yang terdapat dalam permainan, adapun power up yang bisa diperoleh pemain dapat menaikkan atribut power (kekuatan shoot), speed (kecepatan gerak), dan health (jumlah nyawa) pemain. Selain itu, pemain juga dapat melakukan **Upgrade Weapon** dimana pemain dapat membuat senjatanya menjadi lebih kuat, adapun upgrade yang disediakan adalah upgrade untuk menambahkan bullet ke arah diagonal kiri dan kanan pemain, upgrade untuk meningkatkan firing rate senjata, serta upgrade untuk meningkatkan jarak tembakan senjata pemain.

Selain itu, terdapat pula **Local Scoreboard** yang mencatat pencapaian terbaik pemain di setiap game mode, agar nama setiap pemain bisa sesuai dengan kehendak pemain, terdapat fitur untuk mengganti nama pemain menjadi yang diinginkan pada main menu. Adapun untuk skornya akan diurutkan secara descending dari skor terbaik

Di dalam game ini juga terdapat beberapa mobs, yaitu :
1. Zombear, musuh generic dari starter pack yang diberikan
2. Zombunny, musuh generic dari starter pack yang diberikan
3. Hellephant, musuh generic dari starter pack yang diberikan
4. Skeleton, musuh yang tidak dapat bergerak namun dapat menembak pemain
5. Bomber, musuh yang bergerak dengan sangat cepat dan akan meledak dan memberi damage ke pemain jika sudah berada dalam jarak yang dekat dengan pemain
6. Boss, musuh yang kuat dan hanya muncul di wave tertentu

## Cara Kerja Aplikasi

1. Attribute Player

    Untuk fitur attribute player, kami mengimplementasi sebuah script yang mendefinisikan **Player Attribute**, mulai dari informasi atribute power, speed, hingga health player, nantinya ketika pemain meng-trigger / mengambil sebuah orb power up, script tersebut akan langsung melakukan update terhadap atribut pemain sesuai dengan orb power up yang diambil pemain.

2. Orbs

    Untuk fitur orbs, kami memasukkan asset dari setiap orbs ke dalam prefab sehingga mudah untuk di-instantiate nantinya. Kemudian kami membuat script orb manager yang berfungsi untuk mengatur spawn point setiap orb serta meng-invoke perintah untuk meng-spawn orb, adapun orb tersebut akan di-spawn oleh orb factory. Lalu terakhir kami membuat script orb detector yang berfungsi untuk mendeteksi apakah pemain mengambil suatu orb.

3. Additional Mobs

    Untuk fitur additional mobs, kami mengconfigure setiap mob lalu memasukkannya ke dalam prefab sehingga mudah untuk di-instantiate nantinya. Adapun untuk behaviour skeleton, kami mengubah sedikit logic menyerangnya dengan pertama - tama mendeteksi apakah pemain berada dalam shooting range mob, jika pemain berada dalam shooting range mob, maka mob akan mulai menembak ke arah pemain, kami kemudian menambahkan delay pada tembakan skeleton mob kami agar pemain bisa memiliki waktu untuk menghindari tembakan mob.

    Kemudian untuk mob bomber, kami juga mengubah sedikit logic menyerangnya dengan langsung memg-trigger death dari mob ketika mob menyerang player, adapun kami juga memberi delay sebelum mob meledak serta radius ledakan agar player bisa menghindari ledakan dari bomber tersebut.

    Terakhir untuk mob boss, kami tidak mengubah logic apapun terkait attack, hanya membuat bossnya memiliki health yang besar serta power attack yang kuat.

4. Game Mode

    Untuk zen mode, kami hanya menghitung waktu survival pemain dalam script timer manager kemudian menampilkannya dalam HUDCanvas. Adapun kami akan mengformat tampilan waktu survivalnya menjadi format `mm:ss`.

    Untuk wave mode, kami membuat script wave manager yang berfungsi untuk meng-track current wave dan menyimpan state dari current wave tersebut. Adapun state dari wave ada wave number, enemy spawn weight (total weight enemy dalam suatu wave), enemies killed (total musuh yang sudah dikalahkan pemain dalam wave tersebut), total enemy (total musuh yang di-spawn di wave tersebut), current weight, dan is boss wave. State ini kemudian akan dimanfaatkan oleh script wave mode enemy manager dan enemy health, dimana wave mode enemy manager akan meng-spawn musuh sampai weight maksimum wave tercapai, dan enemy health akan mengubah nilai enemies killed ketika suatu musuh berhasil dikalahkan oleh pemain, terakhir ketika `enemiesKilled == totalEnemy`, next wave akan di-trigger, dimana state wave mode manager akan dan UI yang menampilkan current wave akan di-update. Boss akan di-spawn jika `isBossWave = waveNumber % 3 == 0`.

5. Weapon Upgrade

    Untuk fitur weapon upgrade, kami mengimplementasikan 3 upgrade. Yang pertama terdapat diagonal upgrade, pada diagonal upgrade kami membuat penambahan 2 laser pada kanan dan kiri laser utama dengan perbedaan sudut 15 derajat. Lalu untuk setiap upgradenya, akan bertambah 2 terus menerus. Selanjutnya terdapat upgrade kecepatan tembakan,  setiap pemain mengambil upgrade terssebut, maka projectile speed dari laser akan berkurang hingga 0.02. Terakhir adalah upgrade untuk menambah range tembakan, setiap upgrade yang dilakukan, maka jarak tembakan pemain akan bertambah sebanyak 2 float satuan pada game.

6. Local Scoreboard

    Untuk fitur local scoreboard, kami membuat scene baru yang berfungsi untuk menampilkan skor dari pemain untuk setiap game mode. Untuk masing-masing mode, yaitu Zen mode dan juga Wave mode, kami membuat masing-masing sebanyak 1 scene. Kami membuat masing-masing 5 file script yaitu RowUI, Score, ScoreUI, ScoreManager, dan ScoreData. RowUI berfungsi untuk menyediakan model dari kolom mode yang ditampilkan pada UI. Lalu ScoreData berfungsi untuk membuat kelas yang menampung list dari row scoreboard. Selanjutnya terdapat score yang merupakan file ynag menampung kelas entitas dari ScoreData, Lalu juga terdapat ScoreManager yang berfungsi untuk menambah, menyimpan data, dan mengurutkan data. Terakhir terdapat scoreUI yang merupakan file yang berisi fungsi untuk mengisi data setiap row dan dimasukkan kedalam UI pada game.

7. Main Menu

    Untuk fitur main menu, kami membuat scene baru yang terdiri dari beberapa button yang akan meng-trigger command untuk pindah ke scene yang bersesuaian.

8. Game Over

    Untuk fitur game over, kami membuat animasi sederhana yang menampilkan skor pemain, kemudian mengarahkan pemain ke scene game over yang memiliki button untuk memulai kembali permainan, atau kembali ke main menu.

## Library yang Digunakan

Dalam pengerjaan tugas besar ini, kami tidak menggunakan library eksternal, kami hanya memanfaatkan API yang disediakan oleh Unity, seperti **UnityEngine.UI** untuk meng-handle behaviour dari UI kami seperti contohnya **Button**, **InputField**, dan **Text**. Kami juga menggunakan **UnityEngine.SceneManagement** untuk meng-handle behaviour ketika pemain menekan tombol untuk berpindah scene.

## Screenshoot Aplikasi

1. ![Main Menu](/Screenshots/MainMenu.png "Main Menu")
2. ![Change Name](/Screenshots/ChangeName.png "Change Name")
3. ![Wave Mode](/Screenshots/WaveMode.png "Wave Mode")
4. ![Zen Mode](/Screenshots/ZenMode.png "Zen Mode")
5. ![Game Over Zen Mode](/Screenshots/GameOverZen.png "Game Over Zen Mode")
6. ![Game Over Wave Mode](/Screenshots/GameOverWave.png "Game Over Wave Mode")
7. ![Scoreboard Zen Mode](/Screenshots/ScoreboardZen.png "Scoreboard Zen Mode")
8. ![Scoreboard Wave Mode](/Screenshots/ScoreboardWave.png "Scoreboard Wave Mode")

## Pembagian Tugas

| NIM | Nama | Tugas | 
| :---: | :---: | :---: | 
| 13519059 | Denilsen Axel Candiasa| Additional Mobs, Wave Mode, Main Menu, Game Over |
| 13519079 | Jesson Gossal Yo | Attribute Player, Orbs, Zen Mode |
| 13519086 | Marcello Faria | Weapon Upgrade, Local Scoreboard, Game Over, Bonus Weapon Upgrade|
