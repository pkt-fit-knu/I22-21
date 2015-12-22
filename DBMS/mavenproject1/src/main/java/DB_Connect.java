
import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.InputStreamReader;
import static java.lang.Integer.parseInt;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Arrays;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;
import org.json.simple.JSONValue;
import spark.ModelAndView;
import spark.Request;
import static spark.Spark.get;
import static spark.Spark.post;

public class DB_Connect {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws FileNotFoundException {
        // TODO code application logic here

        String jsn_str = null;
        /*try {
         Class.forName("org.postgresql.Driver");
         System.out.println("Postgresql JDBC Driver loaded");
         } catch (ClassNotFoundException e) {
         System.out.println("Driver failed");
         e.printStackTrace();
         return;
         }
         try {
         try (Connection connection = DriverManager.getConnection(
         "jdbc:postgresql://127.0.0.1:5555/bd6",
         "postgres", "root")) {
         System.out.println("good connection");
         try {
         final String query = "SELECT * FROM users INNER JOIN news_users ON users.user_id = news_users.user_id WHERE news_users.news_id=?";
         try (PreparedStatement s = connection.prepareStatement(query)) {
         List l1 = new LinkedList();
         s.setInt(1, 1);
         ResultSet rs = s.executeQuery();
         while (rs.next()) {

         Map m1 = new LinkedHashMap();
         m1.put("user_id", rs.getString("user_id"));
         m1.put("name", rs.getString("name"));
         m1.put("news_id", rs.getString("news_id"));

         l1.add(m1);

         }
         jsn_str = JSONValue.toJSONString(l1);
         }

         } catch (SQLException e) {
         System.out.println("eroor");
         e.printStackTrace();
         }
         }

         } catch (SQLException e) {
         System.out.println("Connection Failed!");
         e.printStackTrace();
         }
         */
        String s = get_one_sql(1);
        System.out.println(s);
        String one_get = read("D:\\fit\\java\\mavenproject1\\src\\main\\resources\\newhtml.html");
       // get("/post", (req, res) -> "");
        get("/", (Request, Response) -> {
            return "" + Response + "||" + Request.queryString() + "||" + Request.queryParams() + "||" + Arrays.toString(Request.queryParamsValues("parameter")) + "||" + Request.queryParamsValues("parameter")[0];
        });
        get("/one_get", (req, res) -> {
            return one_get;
        });
        get("/hello", (Request, res) -> {
            String req = Request.queryParamsValues("parameter")[0];
            try {
                int id = parseInt(req);
                if (id > 0) {
                    return get_one_sql(id);
                } else {
                    return get_one_sql(0);
                }

            } catch (Exception e) {
                System.out.println("ERROR not pars ID!");
                return get_one_sql(0);
            }

            //return get_one_sql(parseInt(Request.queryParamsValues("parameter")[0]));
        });
        get("/hello2", (Request, res) -> {return get_one_sql(0);});

        post("/post", (Request, Response) -> {
            String[] post = {
                Request.queryParamsValues("user_id")[0],
               // Request.queryParamsValues("name")[0],
                Request.queryParamsValues("news_id")[0]
            };
            System.out.println("!!!!!");
            try {
                int user_id = parseInt(post[0]);
                int news_id = parseInt(post[1]);

                System.out.println(user_id + "|"  + news_id + "|");//+ post[1] + "|"
                return update_db(user_id, news_id);
               // return get_one_sql(0);

            } catch (Exception e) {
                System.out.println("ERROR not pars ID!");
                return "Error";
            }

            //return get_one_sql(parseInt(Request.queryParamsValues("parameter")[0]));
        });

        // get("/hello", (req, res) -> get_one_sql(0));
    }
    public static boolean update_db(int user_id, int news_id){
        try {
            Class.forName("org.postgresql.Driver");
            System.out.println("Postgresql JDBC Driver loaded");
        } catch (ClassNotFoundException e) {
            System.out.println("Driver failed");
            e.printStackTrace();
            return false;
        }
        try {
            try (Connection connection = DriverManager.getConnection(
                    "jdbc:postgresql://127.0.0.1:5555/bd6",
                    "postgres", "root")) {
                System.out.println("II good connection");
                try {
                    String query = "INSERT INTO news_users (news_id, user_id) VALUES("+news_id+","+user_id+")";
                    try (PreparedStatement s = connection.prepareStatement(query)) {
                        s.executeUpdate();
                                               
                    }
                } catch (SQLException e) {
                    System.out.println("eroor");
                    e.printStackTrace();
                    return false;
                }
            }
        } catch (SQLException e) {
            System.out.println("Connection Failed!");
            e.printStackTrace();
            return false;
        }
        return true;
    }
    public static String get_one_sql(int parameters) {
        String jsn_str = null;

        try {
            Class.forName("org.postgresql.Driver");
            System.out.println("Postgresql JDBC Driver loaded");
        } catch (ClassNotFoundException e) {
            System.out.println("Driver failed");
            e.printStackTrace();
            return jsn_str;
        }
        try {
            try (Connection connection = DriverManager.getConnection(
                    "jdbc:postgresql://127.0.0.1:5555/bd6",
                    "postgres", "root")) {
                System.out.println("good connection");
                try {
                    String query = "SELECT * FROM users INNER JOIN news_users ON users.user_id = news_users.user_id";
                    if (parameters > 0) {
                        query += " WHERE news_users.news_id=?";
                    }
                    try (PreparedStatement s = connection.prepareStatement(query)) {
                        List l1 = new LinkedList();
                        if (parameters > 0) {
                            s.setInt(1, parameters);
                        }

                        ResultSet rs = s.executeQuery();
                        while (rs.next()) {

                            Map m1 = new LinkedHashMap();
                            m1.put("user_id", rs.getString("user_id"));
                            m1.put("name", rs.getString("name"));
                            m1.put("news_id", rs.getString("news_id"));

                            l1.add(m1);
                        }
                        jsn_str = JSONValue.toJSONString(l1);
                    }

                } catch (SQLException e) {
                    System.out.println("eroor");
                    e.printStackTrace();
                }
            }

        } catch (SQLException e) {
            System.out.println("Connection Failed!");
            e.printStackTrace();
        }
        System.out.println(jsn_str);
        return jsn_str;
    }

    public static String read(String fileName) throws FileNotFoundException {
        //Этот спец. объект для построения строки
        StringBuilder sb = new StringBuilder();
        try {
            //Объект для чтения файла в буфер
             FileInputStream inF = new FileInputStream(fileName);
              //DataInputStream in = new DataInputStream(inF,"Cp866");
              BufferedReader in = new BufferedReader(new InputStreamReader(inF,"UTF8"));

           // BufferedReader in = new BufferedReader(new FileReader(fileName));
            try {
                //В цикле построчно считываем файл
                String s;
                while ((s = in.readLine()) != null) {
                    sb.append(s);
                    sb.append("\n");
                }
            } finally {
                //Также не забываем закрыть файл
                in.close();
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
        //Возвращаем полученный текст с файла
        return sb.toString();
    }
}
