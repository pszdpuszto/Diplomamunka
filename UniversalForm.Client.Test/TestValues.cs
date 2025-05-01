using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalForm.Client.Model;
using UniversalForm.Client.Persistence;

namespace UniversalForm.Client.Test
{
    internal static class TestValues
    {
        public const string DatePatch = "2002-09-19T10:00:00";
        public const string FormName = "testFormName";
        public const string UserName = "testUserName";
        public const string Password = "testPassword";
        public const string FormString = """
            {
              "title": "Test title",
              "description": "Test Description",
              "measureCorrections": false,
              "measureTime": false,
              "anonymous": true,
              "focusTracking": true,
              "allowBack": false,
              "questions": [
                {
                  "$questionType": "QTextArea",
                  "defaultText": "default text",
                  "type": 0,
                  "title": "Text Area",
                  "description": "Description",
                  "required": true
                },
                {
                  "$questionType": "QSingleSelect",
                  "options": [
                    "op2",
                    "op1 "
                  ],
                  "customOption": false,
                  "type": 1,
                  "title": "Single Select",
                  "description": "",
                  "required": false
                },
                {
                  "$questionType": "QMultiSelect",
                  "options": [
                    "op2",
                    "op1"
                  ],
                  "customOption": true,
                  "type": 2,
                  "title": "Multiple Select",
                  "description": "descr",
                  "required": false
                },
                {
                  "$questionType": "QDate",
                  "minDate": "1993-01-01T00:00:00",
                  "maxDate": "2100-01-06T00:00:00",
                  "type": 3,
                  "title": "Date",
                  "description": "desc",
                  "required": false
                },
                {
                  "$questionType": "QNumber",
                  "min": -12,
                  "max": 24,
                  "type": 4,
                  "title": "Number",
                  "description": "descr",
                  "required": true
                }
              ]
            }
            """;

        public static Form Form = new(
            "Test title",
            "Test Description",
            new List<Question>
            {
                new QTextArea("Text Area", "Description", true, "default text"),
                new QSingleSelect("Single Select", "", new List<string> { "op2", "op1 " }, false),
                new QMultiSelect("Multiple Select", "descr", new List<string> { "op2", "op1" }, true),
                new QDate("Date", "desc", DateTime.Parse("1993-01-01"), DateTime.Parse("2100-01-06"), false),
                new QNumber("Number", "descr", -12, 24, true)
            }
            )
        {
            MeasureCorrections = false,
            MeasureTime = false,
            Anonymous = true,
            FocusTracking = true,
            AllowBack = false,
        };

        public static List<string> FormList = new()
        {
            "testForm1",
            "testForm2",
            "testForm3"
        };
        public static string FormListString = """
            [
                "testForm1",
                "testForm2",
                "testForm3"
            ]
            """;
        public static List<Statistics> StatisticsList = new()
        {
            new Statistics(true, new(){"one", "two", "three"}, 5, 1000, 100),
            new Statistics(false, new(){"one"}, 0, 0, 0),
            new Statistics(true, new(){"one", "two"}, 10, 100, 20),
        };
        public static string StatisticsListString =
            """
            {
              "userName": "testUserName",
              "date": "TOPATCH",
              "questionStatistics": [
                {
                  "multipleAnswers": true,
                  "answers": [
                    "one",
                    "two",
                    "three"
                  ],
                  "corrections": 5,
                  "time": 1000,
                  "lostFocusTime": 100
                },
                {
                  "multipleAnswers": false,
                  "answers": [
                    "one"
                  ],
                  "corrections": 0,
                  "time": 0,
                  "lostFocusTime": 0
                },
                {
                  "multipleAnswers": true,
                  "answers": [
                    "one",
                    "two"
                  ],
                  "corrections": 10,
                  "time": 100,
                  "lostFocusTime": 20
                }
              ]
            }
            """.Replace("TOPATCH", DatePatch);
        public static List<FillStatistic> Statistics = new()
        {
            new FillStatistic()
            {
                UserName = "testUserName1",
                Date = DateTime.MinValue,
                QuestionStatistics = StatisticsList
            },
            new FillStatistic()
            {
                UserName = "testUserName2",
                Date = DateTime.MaxValue,
                QuestionStatistics = StatisticsList.Select(s => new Statistics(!s.MultipleAnswers, s.GetMultipleAnswers().Select(a => a.ToUpper()).ToHashSet(), 15-s.Corrections, 5000-s.Time, 2000-s.LostFocusTime)).ToList()
            },
        };
        public static string StatisticsString =
            """
            [
              {
                "userName": "testUserName1",
                "date": "0001-01-01T00:00:00",
                "questionStatistics": [
                  {
                    "multipleAnswers": true,
                    "answers": [
                      "one",
                      "two",
                      "three"
                    ],
                    "corrections": 5,
                    "time": 1000,
                    "lostFocusTime": 100
                  },
                  {
                    "multipleAnswers": false,
                    "answers": [
                      "one"
                    ],
                    "corrections": 0,
                    "time": 0,
                    "lostFocusTime": 0
                  },
                  {
                    "multipleAnswers": true,
                    "answers": [
                      "one",
                      "two"
                    ],
                    "corrections": 10,
                    "time": 100,
                    "lostFocusTime": 20
                  }
                ]
              },
              {
                "userName": "testUserName2",
                "date": "9999-12-31T23:59:59.9999999",
                "questionStatistics": [
                  {
                    "multipleAnswers": false,
                    "answers": [
                      "ONE",
                      "TWO",
                      "THREE"
                    ],
                    "corrections": 10,
                    "time": 4000,
                    "lostFocusTime": 1900
                  },
                  {
                    "multipleAnswers": true,
                    "answers": [
                      "ONE"
                    ],
                    "corrections": 15,
                    "time": 5000,
                    "lostFocusTime": 2000
                  },
                  {
                    "multipleAnswers": false,
                    "answers": [
                      "ONE",
                      "TWO"
                    ],
                    "corrections": 5,
                    "time": 4900,
                    "lostFocusTime": 1980
                  }
                ]
              }
            ]
            """;
    }
}
