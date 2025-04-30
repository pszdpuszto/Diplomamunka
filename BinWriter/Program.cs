var str = """
    {
      "username": "testUserToDelete",
      "password": "OW1OveSosBRkJj9WOMOcFqPzasE3W8SzdO5tIeWvLrI=",
      "forms": [
        "form1",
        "form2",
      ]
    }
    """;

using (var fs = new FileStream("out", FileMode.CreateNew, FileAccess.Write))
{
    using (var bw = new BinaryWriter(fs))
    {
        bw.Write(str);
    }
}