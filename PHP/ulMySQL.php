<?php
class ulMySql
{
  protected $_host = '';
  protected $_port = 3306;
  protected $_user = '';
  protected $_pass = '';
  protected $_dbName = '';
  protected $link = null;
  
  public function __construct()
  {
     $this->_connect();
  }
  
  protected function _connect()
  {
     $this->link = @mysql_connect("{$this->_host}:{$this->_port}",$this->_user,$this->_pass,true);
     if(!$this->link) {
       die("Connect Server Failed: " . mysql_error());
     }
     if(!mysql_select_db($this->_dbName,$this->link)) {
       die("Select Database Failed: " . mysql_error($this->link));
     }
  }
  
  public FUNCTION _close()
  {
     mysql_close($this->link);
     $this->link = NULL;
  }
   
  public FUNCTION ExecSql($sql)
  {
    if(!$this->link)
      $this->_connect();
    $ret = mysql_query($sql, $this->link);
    //mysql_close($this->link); //mysql_error($link)
    $this->_close();
    if ($ret === false)
      $ret = FALSE;
    ELSE 
    	$ret = TRUE;    
    RETURN $ret;
  }  
  
  public FUNCTION GetData($sql)
  {
     if(!$this->link)
      $this->_connect();
     $ret = mysql_query($sql, $this->link);
     $this->_close();//mysql_close($this->link);
     //$res = mysql_fetch_assoc($ret);//�õ����ǵ�һ�����
     $arr = array();
     WHILE ($res = mysql_fetch_array($ret))
     {
        $arr[ ] = $res;
     }     
     RETURN $arr;
  }
  
  public FUNCTION GetVar($sql)
  {
     $ret = '';
     $arr = $this->GetData($sql);
     IF($arr!== false)
       $ret = $arr[0][0];
     RETURN $ret;
  }
  
  public FUNCTION Select($table, $fields = '*', $where = '')
  {
     IF(empty($fields))
       $fields = '*';
     $sql = "SELECT $fields FROM $table ";
     IF($where != '')
       $sql = $sql." WHERE $where";
     RETURN $this->GetData($sql);
  }
  
  public FUNCTION Insert($table, $fields, $data)
  {
    $sql = "INSERT INTO $table($fields)VALUES($data)";
    RETURN $this->ExecSql($sql);
  }
  
  public FUNCTION Update($table, $data, $where)
  {
     $sql = "UPDATE $table SET $data WHERE $where";
     RETURN $this->ExecSql($sql);
  }
  
  public FUNCTION Delete($table, $where)
  {
     $sql = "DELETE FROM $table WHERE $where";
     RETURN $this->ExecSql($sql);
  }
    
}
?>