/**
 * ---------------------------------------
 * This demo was created using amCharts 4.
 *
 * For more information visit:
 * https://www.amcharts.com/
 *
 * Documentation is available at:
 * https://www.amcharts.com/docs/v4/
 * ---------------------------------------
 */

am4core.useTheme(am4themes_animated);

am4core.useTheme(am4themes_animated);
var chart = am4core.create("chartdiv", am4plugins_wordCloud.WordCloud);
var series = chart.series.push(new am4plugins_wordCloud.WordCloudSeries());

series.data = JSON.parse(document.getElementById("hdJsonWords").value);
series.dataFields.word = "Word";
series.dataFields.value = "Count";
series.colors = new am4core.ColorSet();
series.colors.passOptions = {};
series.minFontSize = 16;
series.maxFontSize = 72;
series.randomness = 0.5;

