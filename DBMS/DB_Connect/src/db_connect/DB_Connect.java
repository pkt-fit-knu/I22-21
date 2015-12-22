/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package db_connect;

import java.io.FileWriter;
import java.io.IOException;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.LinkedHashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;
import org.json.simple.JSONValue;

/**
 *
 * @author Дмитро
 */
public class DB_Connect {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        try {
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
                exequteQuery2(connection, 1);
            }

        } catch (SQLException e) {
            System.out.println("Connection Failed!");
            e.printStackTrace();
        }
    }

    public static boolean exequteQuery(Connection c) {
        try {
            try (Statement s = c.createStatement()) {
                ResultSet rs = s.executeQuery("Select * From news");
                while (rs.next()) {
                    for (int i = 1; i < 3; i++) {
                        String abr = rs.getString(1);
                        System.out.println(abr);
                    }
                }
                return true;
            }
        } catch (SQLException e) {
            System.out.println("eroor");
            e.printStackTrace();
            return false;
        }

    }

    public static boolean exequteQuery2(Connection c, int p) {

        try {

            final String query = "SELECT * FROM users INNER JOIN news_users ON users.user_id = news_users.user_id WHERE news_users.news_id=?";
            try (PreparedStatement s = c.prepareStatement(query)) {
                List l1 = new LinkedList();
                s.setInt(1, p);
                ResultSet rs = s.executeQuery();
                while (rs.next()) {
                    /*for (int i = 1; i < 3; i++) {
                     String abr = rs.getString(1);
                     Synamestem.out.println(abr);
                     }*/
                    //System.out.println(rs);
                    Map m1 = new LinkedHashMap();
                    m1.put("user_id", rs.getString("user_id"));
                    m1.put("name", rs.getString("name"));
                    m1.put("news_id", rs.getString("news_id"));

                    l1.add(m1);

                }
                String jsonString = JSONValue.toJSONString(l1);
                System.out.println(jsonString);
                file_write(jsonString);

                return true;
            }

        } catch (SQLException e) {
            System.out.println("eroor");
            e.printStackTrace();
            return false;
        }

    }

    public static void file_write(String s) {
        try (FileWriter writer = new FileWriter("D:\\fit\\java\\notes4.txt", false)) {
            // запись всей строки
            writer.write(s);
            // запись по символам
            writer.append('\n');
            
        } catch (IOException ex) {

            System.out.println(ex.getMessage());
        }
    }

}
