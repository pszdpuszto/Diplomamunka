using System.Text.Json;

var str = """
    [
    {
      "userName": "User1",
      "questionStatistics": [
        {
          "multipleAnswers": false,
          "answers": [
            "ass"
          ],
          "corrections": 0,
          "time": 1459,
          "lostFocusTime": 0
        },
        {
          "multipleAnswers": false,
          "answers": [
            "megezt is"
          ],
          "corrections": 0,
          "time": 1181,
          "lostFocusTime": 0
        },
        {
          "multipleAnswers": false,
          "answers": [
            "2025-04-30"
          ],
          "corrections": 0,
          "time": 3122,
          "lostFocusTime": 0
        },
        {
          "multipleAnswers": false,
          "answers": [
            "12"
          ],
          "corrections": 0,
          "time": 2845,
          "lostFocusTime": 1111
        }
      ]
    },
      {
    "userName": "User2",
    "questionStatistics": [
      {
        "multipleAnswers": false,
        "answers": [
          "idk maaan"
        ],
        "corrections": 0,
        "time": 5124,
        "lostFocusTime": 0
      },
      {
        "multipleAnswers": false,
        "answers": [
          ""
        ],
        "corrections": 2,
        "time": 7363,
        "lostFocusTime": 0
      },
      {
        "multipleAnswers": false,
        "answers": [
          "2001-07-20"
        ],
        "corrections": 3,
        "time": 8897,
        "lostFocusTime": 0
      },
      {
        "multipleAnswers": false,
        "answers": [
          "4"
        ],
        "corrections": 0,
        "time": 3044,
        "lostFocusTime": 905
      }
    ]
    }
    ]
    """;

var list = JsonSerializer.Deserialize<List<string>>(str);
Console.WriteLine(list);