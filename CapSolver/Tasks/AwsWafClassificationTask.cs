﻿using CapSolver.Utilities;
using Newtonsoft.Json;

namespace CapSolver.Tasks;

public class AwsWafClassificationTask : ITask
{
    [JsonProperty("type")]
    private readonly string Type = "AwsWafClassification";

    /// <summary>
    /// Base64-encoded images, do not include "data:image/***;base64,"
    /// </summary>
    [JsonRequired]
    [JsonProperty("images")]
    public IList<string> Images { get; set; }

    /// <summary>
    /// For full names of questions, please refer to the following list of questions.
    /// <br />
    /// See question allow list: <seealso href="https://docs.capsolver.com/guide/recognition/AwsWafClassification.html#create-task">click here</seealso>
    /// </summary>
    [JsonProperty("question", NullValueHandling = NullValueHandling.Include)]
    public string Question { get; set; }

    /// <summary>
    /// Prepare a AwsWafClassification task.
    /// <br/>
    /// See supported types: <seealso href="https://docs.capsolver.com/guide/recognition/AwsWafClassification.html#support-types">click here</seealso>
    /// </summary>
    /// <param name="images">Base64-encoded images, do not include "data:image/***;base64,"Base64-encoded images, do not include "data:image/***;base64,"</param>
    /// <param name="question">For full names of questions, please refer to the following list of questions.</param>
    public AwsWafClassificationTask(IList<string> images,
                                      string question)
    {
        Images = images;
        Question = question;
    }
}
