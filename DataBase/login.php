    <?php
     
        $username = $_REQUEST['username'];
		$password = $_REQUEST['password'];
       
         $database = mysql_connect('localhost', 'embryologie', '3Datlas')or die('Could not connect: ' . mysql_error());
          mysql_select_db('scores') or die('Could not select database');
       
         $query = "SELECT * FROM users WHERE username='".mysql_real_escape_string($username)."'And password='".$password."'";;
            $result=mysql_query($query);
                if (mysql_num_rows($result)>0)
                    echo "right";
       
         else
              echo "wrong";
    ?>